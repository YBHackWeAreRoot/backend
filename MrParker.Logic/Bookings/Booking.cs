using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.Logic.Bookings
{
    public class Booking
    {
        public string Id { get; set; }

        public Booking()
        {
        }

        public Booking(string id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }

        public Task<bool> Create(string parkingSpaceId, DateTime fromTime, DateTime toTime)
        {
            // TODO Verification of validity of from/to for specified Parking-Space

            // TODO implement

            return Task.FromResult(true);
        }

        public Task<bool> Cancel()
        {
            // TODO implement
            return Task.FromResult(true);
        }

        public Task<bool> CheckIn()
        {
            // TODO implement
            return Task.FromResult(true);
        }

        public Task<bool> CheckOut()
        {
            // TODO implement
            return Task.FromResult(true);
        }
    }
}
