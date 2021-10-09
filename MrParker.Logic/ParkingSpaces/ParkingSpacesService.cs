using Microsoft.Extensions.Logging;
using MrParker.DataAccess.Models;
using MrParker.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.Logic.ParkingSpaces
{
    public class ParkingSpacesService
    {

        private ILogger _logger;

        public ParkingSpacesService(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ParkingSpaceSearchResult>> SearchAvailability(decimal positionLat, decimal positionLong, DateTime fromTime, DateTime toTime)
        {
            // TODO Closest Spaces

            // TODO Get Availabilities

            // TODO Match from/to with Slots and Bookings

            // TODO REFACTOR (Presentation Workaround)
            var parkingSpaces = await GetParkingSpacesAsync(positionLat, positionLong) ?? Enumerable.Empty<ParkingSpace>();

            // Get Provider-Data
            var providers = (await new Providers.ProvidersService(_logger)
                .GetProvidersAsync(parkingSpaces.Select(s => s.ProviderId)))
                .ToDictionary(p => p.Id);

            return parkingSpaces.Select(s => new ParkingSpaceSearchResult
            {
                ParkingSpace = s,
                Availability = new EffectiveAvailability
                {
                    FromTime = fromTime.AddHours(-1),
                    ToTime = toTime.AddHours(6),
                    TotalParkingSlots = s.TotalParkingSlots, // TODO Sum of valid Slots
                },
                Provider = providers.TryGetValue(s.ProviderId, out Provider provider) ? provider : null,
            });
        }
        
        public async Task<IEnumerable<ParkingSpace>> GetParkingSpacesAsync(decimal positionLat, decimal positionLong)
        {
            ParkingSpaceRepository repo = new();

            try
            {
                // TODO: Query by coordinates
                return await repo.SelectAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get ParkingSpaces");
            }
            return null;
        }

        public async Task<IEnumerable<ParkingSpace>> GetParkingSpacesAsync(IEnumerable<ParkingSlot> parkingSlots)
        {
            ParkingSpaceRepository repo = new();

            try
            {
                return await repo.SelectAsync("Id IN @ParkingSpaceIds", new { ParkingSpaceIds = parkingSlots.Select(p => p.ParkingSpaceId).ToArray() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get ParkingSpaces");
            }
            return null;
        }

        public async Task<IEnumerable<ParkingSpaceAvailability>> GetAvailabilitiesAsync(IEnumerable<Guid> parkSpaceIds, DateTime fromTime, DateTime toTime)
        {
            ParkingSpaceAvailabilityRepository repo = new();

            try
            {
                return await repo.SelectAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get Availabilities");
            }
            return null;
        }


        public async Task<IEnumerable<ParkingSlot>> GetAvailableSlotsAsync(Guid parkSpaceId, DateTime fromTime, DateTime toTime)
        {
            ParkingSlotRepository repo = new();

            try
            {
                return await repo.SelectAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get Available ParkingSlots");
            }
            return null;
        }

        public async Task<IEnumerable<ParkingSlot>> GetSlotsByCustomerAsync(Guid customerId)
        {
            ParkingSlotRepository repo = new();

            try
            {
                return (await repo.SelectAsync("Id IN (SELECT ParkingSlotId FROM Booking WHERE CustomerId = @CustomerId)",
                                               new { CustomerId = customerId }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get ParkingSlots by CustomerId");
            }
            return null;
        }
    }
}
