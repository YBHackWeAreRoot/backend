using MrParker.ApiModels;
using MrParker.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrParker.Helpers
{
    public static class DataModelExtensions
    {

        public static ProviderDetail GetApiModel(this Provider p)
        {
            if (p == null) { throw new ArgumentNullException(nameof(p)); }
            return new ProviderDetail()
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                ProviderType = ((Logic.Providers.ProviderType)p.ProviderType).ToString(),
                ContactEmail = p.ContactEmail,
                ContactPhone = p.ContactPhone
            };
        }

        public static ParkingSpaceDetail GetApiModel(this ParkingSpace ps, Provider p, DataAccess.Models.Booking b)
        {
            if (ps == null || p == null) { throw new ArgumentNullException($"{(ps == null ? nameof(ps) : "")} {(p == null ? nameof(p) : "")}".Trim()); }
            return new ParkingSpaceDetail()
            {
                Id = ps?.Id.ToString(),
                PositionLat = ps.Latitude,
                PositionLong = ps.Longitude,
                Provider = p.GetApiModel(),
                Address = ps.GetAddress(),
                Capacity = ps.TotalParkingSlots,
                Description = ps.Description,
                Name = ps.Name,
                FromTime = b.FromTime, // TODO: befüllen mit richtigen Werten aus Availability
                ToTime = b.ToTime.AddHours(2), // TODO: befüllen mit richtigen Werten aus Availability
                RatePerMinute = ps.RatePerMinute,
                Currency = ps.Currency
            };

        }

        public static ApiModels.Booking GetApiModel(this DataAccess.Models.Booking b, ParkingSpaceDetail psd)
        {
            if (b == null || psd == null) { throw new ArgumentNullException($"{(b == null ? nameof(b) : "")} {(psd == null ? nameof(psd) : "")}".Trim()); }
            return new ApiModels.Booking()
            {
                Id = b.Id.ToString(),
                CheckedInTime = b.CheckedInTime,
                CheckedOutTime = b.CheckedOutTime,
                Status = ((Logic.Bookings.BookingStatus)b.Status).ToString(),
                ParkingSpace = psd,
                Currency = b.Currency,
                Price = b.Price,
                ReservedFromTime = b.FromTime,
                ReservedToTime = b.ToTime,
                //CreatedDate = b.cre
            };
        }

        public static string GetAddress(this ParkingSpace ps, string separator = ", ")
        {
            string[] parts = new[] { ps.Street, ps.AddrLine2, ps.Zip, ps.City, ps.Country };

            return string.Join(separator, parts.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

    }
}
