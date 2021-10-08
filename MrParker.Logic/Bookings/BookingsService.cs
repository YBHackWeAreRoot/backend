using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.Logic.Bookings
{
    public class BookingsService
    {
        public async Task<bool> Create(string parkingSpaceId, DateTime fromTime, DateTime toTime)
        {
            // TODO Verification of validity of from/to for specified Parking-Space

            // TODO implement
            var booking = new DataAccess.Models.Booking
            {
                CustomerId = (await new Customers.CustomersService().GetCurrentCustomer()).Id,
                // TODO ParkSlotId = ,
                FromTime = fromTime,
                ToTime = toTime,
                Status = (int)BookingStatus.Reserved,
            };

            // TODO implement repo action

            return true;
        }

        public Task<bool> Cancel(string id)
        {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            var booking = new DataAccess.Models.Booking
            {
                Id = Guid.Parse(id),
                Status = (int)BookingStatus.Canceled
            };

            // TODO implement repo action

            return Task.FromResult(true);
        }

        public Task<bool> CheckIn(string id)
        {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            var booking = new DataAccess.Models.Booking
            {
                Id = Guid.Parse(id),
                Status = (int)BookingStatus.CheckedIn,
                CheckedInTime = DateTime.Now,
            };

            // TODO implement repo action

            return Task.FromResult(true);
        }

        public Task<bool> CheckOut(string id)
        {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            var booking = new DataAccess.Models.Booking
            {
                Id = Guid.Parse(id),
                Status = (int)BookingStatus.CheckedOut,
                CheckedOutTime = DateTime.Now,
            };

            // TODO implement repo action

            return Task.FromResult(true);
        }
    }
}
