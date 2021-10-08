using MrParker.DataAccess.Interfaces;
using MrParker.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Repositories
{
    public class ParkSpaceRepository : IRepository<ParkSpace>
    {
        public bool Delete(ParkSpace record)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ParkSpace record)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParkSpace> Select(string condition = null, object parameters = null)
        {
            throw new NotImplementedException();
        }

        public int Update(ParkSpace record, string[] cols = null)
        {
            throw new NotImplementedException();
        }
    }
}
