using MrParker.DataAccess.Interfaces;
using MrParker.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Repositories
{
    public class ParkSlotRepository : IRepository<ParkSlot>
    {
        public bool Delete(ParkSlot record)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ParkSlot record)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParkSlot> Select(string condition = null, object parameters = null)
        {
            throw new NotImplementedException();
        }

        public int Update(ParkSlot record, string[] cols = null)
        {
            throw new NotImplementedException();
        }
    }
}
