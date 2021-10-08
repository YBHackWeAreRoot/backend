using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Models
{
    class ParkSlot
    {

        public long Id { get; set; }

        public int ParkSpaceId { get; set; }

        public int AvailabilityId { get; set; }

    }
}
