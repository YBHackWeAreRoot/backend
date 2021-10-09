using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MrParker.ApiModels;
using MrParker.Helpers;
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
        private readonly ILogger<BookingsController> _logger;
        private Logic.Bookings.BookingsService service;

        public BookingsController(ILogger<BookingsController> logger)
        {
            _logger = logger;
            service = new Logic.Bookings.BookingsService(_logger);
        }

        // GET: api/<BookingsController>
        [HttpGet]
        [Route("api/[controller]/list")]
        public async Task<IEnumerable<Booking>> GetList()
        {
            Logic.Customers.CustomersService cs = new Logic.Customers.CustomersService(_logger);
            DataAccess.Models.Customer customer = await cs.GetCurrentCustomer();
            Logic.ParkingSpaces.ParkingSpacesService pss = new Logic.ParkingSpaces.ParkingSpacesService(_logger);
            IEnumerable<DataAccess.Models.ParkingSlot> slots = await pss.GetSlotsByCustomerAsync(customer.Id);
            IEnumerable<DataAccess.Models.ParkingSpace> spaces = await pss.GetParkingSpacesAsync(slots);
            Logic.Providers.ProvidersService ps = new Logic.Providers.ProvidersService(_logger);
            IEnumerable<DataAccess.Models.Provider> providers = await ps.GetProvidersAsync(spaces.Select(s => s.ProviderId));

            var bookings = await service.GetList(customer.Id);

            if (bookings?.Any() ?? false)
            {
                List<Booking> results = new();
                foreach (DataAccess.Models.Booking b in bookings)
                {
                    // Get Details per Booking
                    var slot = slots?.FirstOrDefault(s => s.Id == b.ParkingSlotId);
                    var parkingSpace = spaces?.FirstOrDefault(s => s.Id == slot?.ParkingSpaceId);
                    var provider = providers.FirstOrDefault(p => p.Id == parkingSpace?.ProviderId);

                    ParkingSpaceDetail psd = parkingSpace.GetApiModel(provider, b);
                    results.Add(b.GetApiModel(psd));
                }
                return results;
            }
            return null;
        }

        [HttpPost]
        [Route("api/[controller]/new")]
        public async Task CreateNew([FromBody] BookingRequest request)
        {
            if (!await service.Create(request.ParkingSpaceId, request.From, request.To))
                Response.StatusCode = 400; // Invalid request
        }

        [HttpPost]
        [Route("api/[controller]/cancel")]
        public async Task Cancel([FromBody] BookingIdentification id)
        {
            if (!await service.Cancel(id.BookingId))
                Response.StatusCode = 400; // Invalid request
        }

        [HttpPost]
        [Route("api/[controller]/checkin")]
        public async Task CheckIn([FromBody] BookingIdentification id)
        {
            if (!await service.CheckIn(id.BookingId))
                Response.StatusCode = 400; // Invalid request
        }

        [HttpPost]
        [Route("api/[controller]/checkout")]
        public async Task CheckOut([FromBody] BookingIdentification id)
        {
            if (!await service.CheckOut(id.BookingId))
                Response.StatusCode = 400; // Invalid request
        }

        [HttpGet]
        [Route("api/[controller]/demoreset")]
        public async Task<string> ResetDemoData()
        {
            //if (!await service.CheckOut())
            //{
            //    Response.StatusCode = 400; // Invalid request
            //    return "error";
            //}

            return "done";
        }
    }
}
