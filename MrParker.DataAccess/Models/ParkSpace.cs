using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Models
{
    public class ParkSpace
    {

        public Guid Id { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public int ProviderId { get; set; }

        public string Street { get; set; }

        public string AddrLine2 { get; set; }

        public string Zip { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int TotalCapacity { get; set; }

        public string Description { get; set; }

        public string CustomerInfo { get; set; }

        public decimal RatePerMinute { get; set; }

        public string Currency { get; set; }

    }
}
