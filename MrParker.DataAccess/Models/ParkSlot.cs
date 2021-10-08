using MrParker.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Models
{
    public class ParkSlot : IModel
    {

        public Guid Id { get; set; }

        public Guid ParkSpaceId { get; set; }

        public int AvailabilityId { get; set; }

    }
}
