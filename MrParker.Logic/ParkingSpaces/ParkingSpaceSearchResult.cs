using MrParker.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.Logic.ParkingSpaces
{
    public class ParkingSpaceSearchResult
    {
        public ParkingSpace ParkingSpace { get; set; }
        public Provider Provider { get; set; }
        public EffectiveAvailability Availability { get; set; }
    }
}
