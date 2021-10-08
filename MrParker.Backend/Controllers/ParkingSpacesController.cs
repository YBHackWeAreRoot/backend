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
        public IEnumerable<ParkingSpaceDetail> Search(string position, DateTime from, DateTime to)
        {
            // TODO Position Check: 
            // - Comma separated lat,long
            // - max. 6 decimal places

            if (from == DateTime.MinValue || to == DateTime.MinValue)
                return Enumerable.Empty<ParkingSpaceDetail>();

            return new[] { 
                new ParkingSpaceDetail
                {
                    Id = "39577d63-1336-47bb-94ec-f5885caf0085",
                    Name = "EWB Hauptsitz",
                    Provider = new ProviderDetail
                    {
                        Id = "3a59ac04-a2b4-498d-a637-974e938afbd2",
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
                    Capacity = 45
                },
                new ParkingSpaceDetail
                {
                    Id = "fa9ad634-0561-46b7-aaa7-7f56719c83b1",
                    Name = "Parkplatz",
                    Provider = new ProviderDetail
                    {
                        Id = "bd978559-54e5-471b-8ded-9c3dcff62d2c",
                        Name = "Moriz Müller",
                        ProviderType = "Private",
                        ContactEmail = "moriz@mueller",
                        ContactPhone = "+41794561283",
                    },
                    Address = "Klösterlistutz 20, \n3013 Bern",
                    Currency = "CHF",
                    FromTime = from.AddHours(-4),
                    ToTime = to.AddDays(1),
                    PositionLat = 46.948580M,
                    PositionLong = 7.459832M,
                    RatePerMinute = .015M,
                    Capacity = 1
                }
            };
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
                    Id = "3a59ac04-a2b4-498d-a637-974e938afbd2",
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
