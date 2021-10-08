using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrParker.ApiModels
{
    public class ParkingSpaceDetail
    {
        public string Id { get; set; }
        public ProviderDetail Provider { get; set; }
        public decimal PositionLat { get; set; }
        public decimal PositionLong { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public decimal RatePerMinute { get; set; }
        public string Currency { get; set; }
        public int Capacity { get; set; }
    }
}
