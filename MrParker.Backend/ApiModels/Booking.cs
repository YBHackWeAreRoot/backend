using MrParker.Logic.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrParker.ApiModels
{
    public class Booking
    {
        public string Id { get; set; }
        public ParkingSpaceDetail ParkingSpace { get; set; }
        public DateTime ReservedFromTime { get; set; }
        public DateTime ReservedToTime { get; set; }
        public string Status { get; set; }
        public DateTime? CheckedInTime { get; set; }
        public DateTime? CheckedOutTime { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
