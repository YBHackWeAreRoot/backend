using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrParker.ApiModels
{
    public class BookingRequest
    {
        public string ParkingSpaceId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
