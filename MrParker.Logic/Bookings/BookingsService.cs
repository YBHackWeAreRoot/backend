using Microsoft.Extensions.Logging;
using MrParker.DataAccess.Models;
using MrParker.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.Logic.Bookings
{
    public class BookingsService
    {
        private ILogger _logger;
        private BookingRepository repository;

        public BookingsService(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            repository = new BookingRepository();
        }

        public async Task<IEnumerable<Booking>> GetList(Guid customerId)
        {
            try
            {
                return await repository.SelectAsync("CustomerId = @CustomerId", new { CustomerId = customerId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get Booking List");
            }
            return null;
        }

        public async Task<bool> Create(string parkingSpaceId, DateTime fromTime, DateTime toTime)
        {
            var parkingSpaceService = new ParkingSpaces.ParkingSpacesService(_logger);

            var parkingSpace = await parkingSpaceService.GetParkingSpaceAsync(Guid.Parse(parkingSpaceId));
            if (parkingSpace == null)
                return false; // No matching Parking Space

            // TODO Find and validate available Slot by from/to
            var availableSlots = await new ParkingSpaces.ParkingSpacesService(_logger)
                .GetAvailableSlotsAsync(Guid.Parse(parkingSpaceId), fromTime, toTime);

            if (!availableSlots.Any())
                return false; // No matching Slots

            // Insert new Booking
            try
            {
                await repository.InsertAsync(new Booking
                {
                    CustomerId = (await new Customers.CustomersService(_logger).GetCurrentCustomer()).Id,
                    ParkingSlotId = availableSlots.First().Id,
                    FromTime = fromTime,
                    ToTime = toTime,
                    Status = (int)BookingStatus.Reserved,
                    Currency = parkingSpace.Currency,
                    Price = Convert.ToDecimal((toTime - fromTime).TotalMinutes) * parkingSpace.RatePerMinute,
                    CreatedDate = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Insert Booking");
                return false;
            }

            return true;
        }

        public async Task<bool> Cancel(string id)
        {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            try
            {
                await repository.UpdateAsync(
                    new Booking
                    {
                        Id = Guid.Parse(id),
                        Status = (int)BookingStatus.Canceled
                    },
                    new[] { "Status" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Set Booking cancelled");
                return false;
            }

            return true;
        }

        public async Task<bool> CancelBySystem(string id)
        {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            try
            {
                await repository.UpdateAsync(
                    new DataAccess.Models.Booking
                    {
                        Id = Guid.Parse(id),
                        Status = (int)BookingStatus.CanceledBySystem
                    },
                    new[] { "Status" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Set Booking cancelled by System");
                return false;
            }

            return true;
        }

        public async Task<bool> CheckIn(string id)
        {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            try
            {
                await repository.UpdateAsync(
                    new Booking
                    {
                        Id = Guid.Parse(id),
                        CheckedInTime = DateTime.Now,
                        Status = (int)BookingStatus.CheckedIn
                    },
                    new[] { "CheckedInTime", "Status" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Check-In Booking");
                return false;
            }

            return true;
        }

        public async Task<bool> CheckOut(string id)
        {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            try
            {
                await repository.UpdateAsync(
                    new Booking
                    {
                        Id = Guid.Parse(id),
                        CheckedOutTime = DateTime.Now,
                        Status = (int)BookingStatus.CheckedOut
                    },
                    new[] { "CheckedOutTime", "Status" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Check-Out Booking");
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteNewBookings(DateTime newerThan)
        {
            try
            {
                await repository.DeleteByConditionAsync("CreatedDate > @CreatedDate", new { CreatedDate = newerThan });
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Delete Bookings by Condition");
            }
            return false;
        }
    }
}
