﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Models
{
    public class Booking
    {

        public Guid Id { get; set; }

        public int ParkSlotId { get; set; }

        public DateTime FromTime {get; set;}

        public DateTime ToTime { get; set; }

        public int CustomerId { get; set; }

        public int Status { get; set; }

        public DateTime? CheckedInTime { get; set; }

        public DateTime? CheckedOutTime { get; set; }

    }
}
