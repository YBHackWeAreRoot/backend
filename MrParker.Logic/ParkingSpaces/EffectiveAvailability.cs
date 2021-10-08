using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.Logic.ParkingSpaces
{
    public class EffectiveAvailability
    {
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public int Capacity { get; set; }
    }
}
