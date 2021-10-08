using MrParker.DataAccess.Interfaces;
using MrParker.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Repositories
{
    public class ProviderRepository : IRepository<Provider>
    {
        public bool Delete(Provider record)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Provider record)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Provider> Select(string condition = null, object parameters = null)
        {
            throw new NotImplementedException();
        }

        public int Update(Provider record, string[] cols = null)
        {
            throw new NotImplementedException();
        }
    }
}
