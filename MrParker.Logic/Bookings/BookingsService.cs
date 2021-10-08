using Microsoft.Extensions.Logging;
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
        private DataAccess.Repositories.BookingRepository repository;

        public BookingsService(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            repository = new DataAccess.Repositories.BookingRepository();
        }

        //public async Task<IEnumerable<DataAccess.Models.Booking>> GetList(Guid customerId)
        //{

        //}

        public async Task<bool> Create(string parkingSpaceId, DateTime fromTime, DateTime toTime)
        {
            // TODO Verification of validity of from/to for specified Parking-Space

            // Insert new Booking
            try
            {
                await repository.InsertAsync(new DataAccess.Models.Booking
                {
                    CustomerId = (await new Customers.CustomersService(_logger).GetCurrentCustomer()).Id,
                    // TODO ParkSlotId = ,
                    FromTime = fromTime,
                    ToTime = toTime,
                    Status = (int)BookingStatus.Reserved,
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
                    new DataAccess.Models.Booking
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

        public async Task<bool> CheckIn(string id)
        {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            try
            {
                await repository.UpdateAsync(
                    new DataAccess.Models.Booking
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
                    new DataAccess.Models.Booking
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
    }
}
