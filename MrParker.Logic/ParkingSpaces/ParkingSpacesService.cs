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
            ParkingSpaceAvailabilityRepository repo = new();

            // TODO

            return null;
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


    }
}
