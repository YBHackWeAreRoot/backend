using MrParker.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Models
{
    public class ParkingSlot : IModel
    {

        public Guid Id { get; set; }

        public Guid ParkingSpaceId { get; set; }

    }
}
