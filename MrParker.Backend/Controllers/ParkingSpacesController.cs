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
                    RatePerMinute = s.Price,
                    Capacity = s.Availability.Capacity,
                    Description = s.ParkingSpace.Description
                });

            //return new[] { 
            //    new ParkingSpaceDetail
            //    {
            //        Id = "ca7b4ff3-2bcb-499a-86aa-67a0760594f8",
            //        Name = "EWB Hauptsitz",
            //        Provider = new ProviderDetail
            //        {
            //            Id = "3705f1cd-02ac-47b7-95c3-15c3143add59",
            //            Name = "EWB",
            //            ProviderType = "Company",
            //            ContactEmail = "info@ewb.ch",
            //            ContactPhone = "+41 12 345 67 89"
            //        },
            //        Address = "Monbijoustrasse 11, \n3011 Bern",
            //        Currency = "CHF",
            //        FromTime = from.AddHours(-1),
            //        ToTime = to.AddHours(6),
            //        PositionLat = 46.944840M,
            //        PositionLong = 7.436910M,
            //        RatePerMinute = .01M,
            //        Capacity = 45
            //    },
            //    new ParkingSpaceDetail
            //    {
            //        Id = "3809a2eb-c8fc-4ba1-b920-8295c2385233",
            //        Name = "Parkplatz",
            //        Provider = new ProviderDetail
            //        {
            //            Id = "0123636b-0c0e-4d57-a505-0f9e13a71178", // TODO from DB
            //            Name = "Moriz Müller",
            //            ProviderType = "Private",
            //            ContactEmail = "moriz@mueller.ch",
            //            ContactPhone = "+41794561283",
            //        },
            //        Address = "Klösterlistutz 20, \n3013 Bern",
            //        Currency = "CHF",
            //        FromTime = from.AddHours(-4),
            //        ToTime = to.AddDays(1),
            //        PositionLat = 46.948580M,
            //        PositionLong = 7.459832M,
            //        RatePerMinute = .015M,
            //        Capacity = 1
            //    },
            //    new ParkingSpaceDetail
            //    {
            //        Id = "0771fbeb-2f88-4789-a91a-680ba47d6898",
            //        Name = "Bern EXPO",
            //        Provider = new ProviderDetail // TODO from DB
            //        {
            //            Id = "ba2b30e8-2201-44a7-9745-07f7b1202da6",
            //            Name = "Contoso",
            //            ProviderType = "Company",
            //            ContactPhone = "+41794561243"
            //        },
            //        Address = "Mingerstrasse 6, \n3014 Bern",
            //        Currency = "CHF",
            //        FromTime = from.AddMinutes(-30),
            //        ToTime = to.AddHours(5),
            //        PositionLat = 46.9604707M,
            //        PositionLong = 7.4666359M,
            //        RatePerMinute = .2M,
            //        Capacity = 12,
            //    },
            //    new ParkingSpaceDetail
            //    {
            //        Id = "b47ab107-2762-4d3f-a392-4313c8966c57",
            //        Name = "Bern EXPO - RESERVE",
            //        Provider = new ProviderDetail
            //        {
            //            Id = "ba2b30e8-2201-44a7-9745-07f7b1202da6",
            //            Name = "Contoso",
            //            ProviderType = "Company",
            //            ContactPhone = "+41794561243"
            //        },
            //        Address = "Mingerstrasse 6, \n3014 Bern",
            //        Currency = "CHF",
            //        FromTime = from.AddMinutes(30),
            //        ToTime = to.AddHours(5),
            //        PositionLat = 46.9599967M,
            //        PositionLong = 7.4660901M,
            //        RatePerMinute = .2M,
            //        Capacity = 12,
            //    },
            //    new ParkingSpaceDetail
            //    {
            //        Id = "26c32cac-b73a-422c-baae-b8f95b2af0c0",
            //        Name = "Bern EXPO - RESTRICTED",
            //        Provider = new ProviderDetail
            //        {
            //            Id = "ba2b30e8-2201-44a7-9745-07f7b1202da6",
            //            Name = "Contoso",
            //            ProviderType = "Company",
            //            ContactPhone = "+41794561243"
            //        },
            //        Address = "Mingerstrasse 6, \n3014 Bern",
            //        Currency = "CHF",
            //        FromTime = from,
            //        ToTime = to.AddHours(5),
            //        PositionLat = 46.9606667M,
            //        PositionLong = 7.4666480M,
            //        RatePerMinute = .2M,
            //        Capacity = 12,
            //    }
            //};
        }

        // GET api/<ParkingSpacesController>/5
        [HttpGet]
        [Route("api/[controller]/detail")]
        public ParkingSpaceDetail Detail(string id, DateTime from, DateTime to)
        {
            if (from == DateTime.MinValue || to == DateTime.MinValue)
                return null;

            return new ParkingSpaceDetail
            {
                Id = id,
                Name = "Some parking slot",
                Provider = new ProviderDetail
                {
                    Id = "3705f1cd-02ac-47b7-95c3-15c3143add59",
                    Name = "EWB",
                    ProviderType = "Company",
                    ContactEmail = "info@ewb.ch",
                    ContactPhone = "+41 12 345 67 89"
                },
                Address = "Monbijoustrasse 11, \n3011 Bern",
                Currency = "CHF",
                FromTime = from.AddHours(-1),
                ToTime = to.AddHours(6),
                PositionLat = 46.944840M,
                PositionLong = 7.436910M,
                RatePerMinute = .01M,
                Capacity = 45,
                Description = "Description ...",
            };
        }
    }
}
