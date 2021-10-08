using MrParker.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Models
{
    public class Booking : IModel
    {

        public Guid Id { get; set; }

        public Guid ParkingSlotId { get; set; }

        public DateTime FromTime {get; set;}

        public DateTime ToTime { get; set; }

        public Guid CustomerId { get; set; }

        public int Status { get; set; }

        public DateTime? CheckedInTime { get; set; }

        public DateTime? CheckedOutTime { get; set; }

    }
}
