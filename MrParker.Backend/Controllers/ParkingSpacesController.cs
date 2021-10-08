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
        public IEnumerable<ParkSpaceSearchResult> Get(string position, DateTime from, DateTime to)
        {
            return new[] { 
                new ParkSpaceSearchResult
                {
                    Id = "1",
                    ProviderName = "EWB",
                    Address = "Monbijoustrasse 11, \n3011 Bern",
                    Currency = "CHF",
                    Description = "Description...",
                    FromTime = from.AddHours(-1),
                    ToTime = to.AddHours(6),
                    PositionLat = 46.944840M,
                    PositionLong = 7.436910M,
                    RatePerMinute = .1M,
                    Capacity = 45
                },
                new ParkSpaceSearchResult
                {
                    Id = "2",
                    ProviderName = "Muster Hans",
                    Address = "Klösterlistutz 20, \n3013 Bern",
                    Currency = "CHF",
                    Description = "Description...",
                    FromTime = from.AddHours(-4),
                    ToTime = to.AddDays(1),
                    PositionLat = 46.948580M,
                    PositionLong = 7.459832M,
                    RatePerMinute = .15M,
                    Capacity = 1
                }
            };
        }

        //// GET api/<ParkingSpacesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

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
