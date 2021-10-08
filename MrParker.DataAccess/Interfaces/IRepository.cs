using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Interfaces
{
    interface IRepository<T>
    {
        
        public Task<IEnumerable<T>> SelectAsync(string condition = null, object parameters = null);

        public Task<bool> InsertAsync(T record);

        public Task<bool> UpdateAsync(T record, object parameters);

        public Task<bool> DeleteAsync(T record);

    }
}
