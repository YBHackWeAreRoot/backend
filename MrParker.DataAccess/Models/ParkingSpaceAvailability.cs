using MrParker.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Models
{
    public class ParkingSpaceAvailability : IModel
    {

        public Guid Id { get; set; }

        public Guid ParkingSpaceId { get; set; }

        public byte? WeekDay { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? FromTime { get; set; }

        public DateTime? ToTime { get; set; }

    }

}
