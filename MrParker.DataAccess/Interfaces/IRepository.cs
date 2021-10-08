using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Interfaces
{
    interface IRepository<T>
    {

        public IEnumerable<T> Select(string condition = null, object parameters = null);

        public bool Insert(T record);

        public int Update(T record, string[] cols = null);

        public bool Delete(T record);

    }
}
