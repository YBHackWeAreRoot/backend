﻿using Microsoft.AspNetCore.Mvc;
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
                Id = "3916b625-046c-4762-af06-5b37e4efbb87",
                ParkingSpace = new ParkingSpaceDetail
                {
                    Id = "39577d63-1336-47bb-94ec-f5885caf0085",
                    Name = "Monbijou",
                    Provider = new ProviderDetail // TODO from DB
                    {
                        Id = "3705f1cd-02ac-47b7-95c3-15c3143add59",
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
                ReservedFromTime = DateTime.Now.AddMinutes(50),
                ReservedToTime = DateTime.Now.AddHours(3).AddMinutes(50),
                Status = Logic.Bookings.BookingStatus.Reserved.ToString(),
                CheckedInTime = null,
                CheckedOutTime = null,
                Price = Math.Round(.01M * 60 * 3, 2),
                Currency = "CHF"
            },
            new Booking
            {
                Id = "80e76d20-da25-4ce0-ba4c-b12a5b96295c",
                ParkingSpace = new ParkingSpaceDetail
                {
                    Id = "39577d63-1336-47bb-94ec-f5885caf0085",
                    Name = "Headquarters",
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
                Id = "846cbe7f-62ba-43e7-9e09-e5611344685e",
                ParkingSpace = new ParkingSpaceDetail
                {
                    Id = "39577d63-1336-47bb-94ec-f5885caf0085",
                    Name = "Tiefgarage A",
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
                Id = "d3621fcc-aee3-4208-91fc-0676d31619ff",
                ParkingSpace = new ParkingSpaceDetail
                {
                    Id = "39577d63-1336-47bb-94ec-f5885caf0085",
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
                    var slot = slots?.FirstOrDefault(s => s.Id == b.ParkingSlotId);
                    var parkingSpace = spaces?.FirstOrDefault(s => s.Id == slot?.ParkingSpaceId);
                    ParkingSpaceDetail psd = new()
                    {
                        Id = parkingSpace.Id.ToString(),
                        PositionLat = parkingSpace.Latitude,
                        PositionLong = parkingSpace.Longitude,
                        Provider = null, // TODO: Provider befüllen
                        Address = $"{parkingSpace.Street}, {parkingSpace.AddrLine2}, {parkingSpace.Zip}, {parkingSpace.City}, {parkingSpace.Country}".Replace(", ,", ", "),
                        Capacity = parkingSpace.TotalParkingSlots, // TODO: Stimmt das so?
                        Description = parkingSpace.Description,
                        Name = parkingSpace.Name,
                        FromTime = DateTime.MinValue, // TODO: befüllen
                        ToTime = DateTime.MaxValue, // TODO: befüllen
                        RatePerMinute = parkingSpace.RatePerMinute,
                        Currency = parkingSpace.Currency
                    };

                    // TODO: restliche Daten befüllen

                    results.Add(new Booking()
                    {
                        Id = b.Id.ToString(),
                        CheckedInTime = b.CheckedInTime,
                        CheckedOutTime = b.CheckedOutTime,
                        Status = b.Status.ToString(),
                        ParkingSpace = psd
                    });
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
    }
}
