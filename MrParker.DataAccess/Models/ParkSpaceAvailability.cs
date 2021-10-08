using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Models
{
    public class ParkSpaceAvailability
    {

        public int Id { get; set; }

        public int ParkSpaceId { get; set; }

        public byte? WeekDay { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? FromTime { get; set; }

        public DateTime? ToTime { get; set; }

    }

}
