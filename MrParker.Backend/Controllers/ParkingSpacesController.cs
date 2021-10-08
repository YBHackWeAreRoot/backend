using Microsoft.AspNetCore.Mvc;
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
        // GET: api/<ParkingSpacesController>
        [HttpGet]
        [Route("api/[controller]/search")]
        public IEnumerable<ParkingSpaceSearchResult> Search(string position, DateTime from, DateTime to)
        {
            // TODO Position Check: 
            // - Comma separated lat,long
            // - max. 6 decimal places

            if (from == DateTime.MinValue || to == DateTime.MinValue)
                return Enumerable.Empty<ParkingSpaceSearchResult>();

            return new[] { 
                new ParkingSpaceSearchResult
                {
                    Id = "1",
                    ProviderName = "EWB",
                    Address = "Monbijoustrasse 11, \n3011 Bern",
                    Currency = "CHF",
                    FromTime = from.AddHours(-1),
                    ToTime = to.AddHours(6),
                    PositionLat = 46.944840M,
                    PositionLong = 7.436910M,
                    RatePerMinute = .1M,
                    Capacity = 45
                },
                new ParkingSpaceSearchResult
                {
                    Id = "2",
                    ProviderName = "Muster Hans",
                    Address = "Klösterlistutz 20, \n3013 Bern",
                    Currency = "CHF",
                    FromTime = from.AddHours(-4),
                    ToTime = to.AddDays(1),
                    PositionLat = 46.948580M,
                    PositionLong = 7.459832M,
                    RatePerMinute = .15M,
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
                Provider = new ProviderDetail
                {
                    Id = "11",
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
                RatePerMinute = .1M,
                Capacity = 45,
                Description = "Description ...",
            };
        }

        //// POST api/<ParkingSpacesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ParkingSpacesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ParkingSpacesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
