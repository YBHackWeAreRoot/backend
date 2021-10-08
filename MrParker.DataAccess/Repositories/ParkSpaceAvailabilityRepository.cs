using MrParker.DataAccess.Interfaces;
using MrParker.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Repositories
{
    public class ParkSpaceAvailabilityRepository : IRepository<ParkSpaceAvailability>
    {
        public bool Delete(ParkSpaceAvailability record)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ParkSpaceAvailability record)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParkSpaceAvailability> Select(string condition = null, object parameters = null)
        {
            throw new NotImplementedException();
        }

        public int Update(ParkSpaceAvailability record, string[] cols = null)
        {
            throw new NotImplementedException();
        }
    }
}
