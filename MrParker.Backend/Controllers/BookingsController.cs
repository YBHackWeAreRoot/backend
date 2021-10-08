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
    public class BookingsController : ControllerBase
    {
        // TODO Mock-Data entfernen
        private readonly Booking[] mockedBookings = new[]
        {
            new Booking
            {
                Id = "3acb",
                ParkingSpace = new ParkingSpaceDetail
                {
                    Id = "1",
                    Name = "Some parking slot",
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
                    FromTime = DateTime.Now.AddDays(1).AddHours(-1),
                    ToTime = DateTime.Now.AddDays(2).AddHours(6),
                    PositionLat = 46.944840M,
                    PositionLong = 7.436910M,
                    RatePerMinute = .01M,
                    Capacity = 45,
                    Description = "Description ...",
                },
                ReservedFromTime = DateTime.Now.AddDays(1).AddHours(-1),
                ReservedToTime = DateTime.Now.AddDays(1).AddHours(5),
                Status = Logic.Bookings.BookingStatus.Reserved.ToString(),
                CheckedInTime = null,
                CheckedOutTime = null,
                Price = Math.Round(.01M * 60 * 6, 2),
                Currency = "CHF"
            },
            new Booking
            {
                Id = "2b09",
                ParkingSpace = new ParkingSpaceDetail
                {
                    Id = "1",
                    Name = "Some parking slot",
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
                    FromTime = DateTime.Now.AddDays(1).AddHours(-1),
                    ToTime = DateTime.Now.AddDays(2).AddHours(6),
                    PositionLat = 46.944840M,
                    PositionLong = 7.436910M,
                    RatePerMinute = .01M,
                    Capacity = 45,
                    Description = "Description ...",
                },
                ReservedFromTime = new DateTime(2021, 8, 8, 21, 0, 0),
                ReservedToTime = new DateTime(2021, 8, 9, 1, 0, 0),
                Status = Logic.Bookings.BookingStatus.CheckedOut.ToString(),
                CheckedInTime = new DateTime(2021, 8, 8, 21, 7, 3),
                CheckedOutTime = new DateTime(2021, 8, 9, 0, 51, 45),
                Price = Math.Round(.01M * Convert.ToDecimal((new DateTime(2021, 8, 9, 0, 51, 45) - new DateTime(2021, 8, 8, 21, 7, 3)).TotalMinutes), 2),
                Currency = "CHF"
            },
            new Booking
            {
                Id = "1def",
                ParkingSpace = new ParkingSpaceDetail
                {
                    Id = "1",
                    Name = "Some parking slot",
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
                    FromTime = DateTime.Now.AddDays(1).AddHours(-1),
                    ToTime = DateTime.Now.AddDays(2).AddHours(6),
                    PositionLat = 46.944840M,
                    PositionLong = 7.436910M,
                    RatePerMinute = .01M,
                    Capacity = 45,
                    Description = "Description ...",
                },
                ReservedFromTime = new DateTime(2021, 1, 8, 10, 0, 0),
                ReservedToTime = new DateTime(2021, 1, 8, 12, 0, 0),
                Status = Logic.Bookings.BookingStatus.CheckedOut.ToString(),
                CheckedInTime = new DateTime(2021, 1, 8, 10, 03, 34),
                CheckedOutTime = new DateTime(2021, 1, 8, 11, 33, 5),
                Price = Math.Round(.01M * Convert.ToDecimal((new DateTime(2021, 1, 8, 11, 33, 5) - new DateTime(2021, 1, 8, 10, 03, 34)).TotalMinutes), 2),
                Currency = "CHF"
            }
        };

        private readonly ILogger<BookingsController> _logger;

        public BookingsController(ILogger<BookingsController> logger)
        {
            _logger = logger;
        }

        // GET: api/<BookingsController>
        [HttpGet]
        [Route("api/[controller]/list")]
        public IEnumerable<Booking> Get()
        {
            return mockedBookings;
        }

        //// GET api/<BookingsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<BookingsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<BookingsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<BookingsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
