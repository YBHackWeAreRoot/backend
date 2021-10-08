using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Models
{
    public class Booking
    {

        public int Id { get; set; }

        public int ParkSlotId { get; set; }

        public DateTime FromTime {get; set;}

        public DateTime ToTime { get; set; }

        public int CustomerId { get; set; }

    }
}
