using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MrParker.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MrParker.Controllers
{
    [ApiController]
    public class ParkingSpacesController : ControllerBase
    {
        private readonly ILogger<ParkingSpacesController> _logger;

        public ParkingSpacesController(ILogger<ParkingSpacesController> logger)
        {
            _logger = logger;
        }

        // GET: api/<ParkingSpacesController>
        [HttpGet]
        [Route("api/[controller]/search")]
        public async Task<IEnumerable<ParkingSpaceDetail>> Search(string position, DateTime from, DateTime to)
        {
            // TODO Position Check: 
            // - Comma separated lat,long
            // - max. 6 decimal places

            if (from == DateTime.MinValue || to == DateTime.MinValue)
                return Enumerable.Empty<ParkingSpaceDetail>();

            var coordinates = position?.Split(',') ?? new[] { "0", "0" };

            return (await new Logic.ParkingSpaces.ParkingSpacesService(_logger)
                .SearchAvailability(
                    positionLat: decimal.Parse(coordinates[0]),
                    positionLong: decimal.Parse(coordinates[1]),
                    from,
                    to))
                .Select(s => new ParkingSpaceDetail
                {
                    Id = s.ParkingSpace.Id.ToString(),
                    Name = s.ParkingSpace.Name,
                    Provider = new ProviderDetail
                    {
                        Id = s.Provider.Id.ToString(),
                        Name = s.Provider.Name,
                        ProviderType = ((Logic.Providers.ProviderType)s.Provider.ProviderType).ToString(),
                        ContactEmail = s.Provider.ContactEmail,
                        ContactPhone = s.Provider.ContactPhone
                    },
                    Address = $"{s.ParkingSpace.Street}, \n{s.ParkingSpace.Zip} {s.ParkingSpace.City}", // TODO AddressLine2, Country
                    Currency = s.ParkingSpace.Currency,
                    FromTime = s.Availability.FromTime,
                    ToTime = s.Availability.ToTime,
                    PositionLat = s.ParkingSpace.Latitude,
                    PositionLong = s.ParkingSpace.Longitude,
                    RatePerMinute = s.ParkingSpace.RatePerMinute,
                    Capacity = s.Availability.TotalParkingSlots,
                    Description = s.ParkingSpace.Description
                });
        }

        // GET api/<ParkingSpacesController>/5
        [HttpGet]
        [Route("api/[controller]/detail")]
        public async Task<ParkingSpaceDetail> Detail(string id, DateTime from, DateTime to)
        {
            if (from == DateTime.MinValue || to == DateTime.MinValue)
                return null;

            var availability = await new Logic.ParkingSpaces.ParkingSpacesService(_logger)
                .GetSingleAvailability(id, from, to);

            return new ParkingSpaceDetail
            {
                Id = availability.ParkingSpace.Id.ToString(),
                Name = availability.ParkingSpace.Name,
                Provider = new ProviderDetail
                {
                    Id = availability.Provider.Id.ToString(),
                    Name = availability.Provider.Name,
                    ProviderType = ((Logic.Providers.ProviderType)availability.Provider.ProviderType).ToString(),
                    ContactEmail = availability.Provider.ContactEmail,
                    ContactPhone = availability.Provider.ContactPhone
                },
                Address = $"{availability.ParkingSpace.Street}, \n{availability.ParkingSpace.Zip} {availability.ParkingSpace.City}", // TODO AddressLine2, Country
                Currency = availability.ParkingSpace.Currency,
                FromTime = availability.Availability.FromTime,
                ToTime = availability.Availability.ToTime,
                PositionLat = availability.ParkingSpace.Latitude,
                PositionLong = availability.ParkingSpace.Longitude,
                RatePerMinute = availability.ParkingSpace.RatePerMinute,
                Capacity = availability.Availability.TotalParkingSlots,
                Description = availability.ParkingSpace.Description
            };
        }
    }
}
