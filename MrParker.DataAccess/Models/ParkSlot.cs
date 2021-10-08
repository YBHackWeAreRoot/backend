using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Models
{
    public class ParkSlot
    {

        public Guid Id { get; set; }

        public int ParkSpaceId { get; set; }

        public int AvailabilityId { get; set; }

    }
}
