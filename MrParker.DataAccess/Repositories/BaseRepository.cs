using Dapper;
using MrParker.DataAccess.Helpers;
using MrParker.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : IModel
    {

        public async Task<IEnumerable<T>> SelectAsync(string condition = null, object parameters = null)
        {
            using var db = SqlConnectionProvider.CreateConnection();
            return await db.QueryAsync<T>($"SELECT * FROM [{typeof(T).Name}]{(condition != null ? $" WHERE {condition}" : "")};", parameters);
        }

        public async Task<bool> InsertAsync(T record)
        {
            using var db = SqlConnectionProvider.CreateConnection();
            db.Open();

            return await db.InsertAsync<Guid, T>(record) != Guid.Empty;
        }

        public async Task<bool> UpdateAsync(T record, object parameters)
        {
            using var db = SqlConnectionProvider.CreateConnection();
            db.Open();

            Dictionary<string, object> dict = new Dictionary<string, object>();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(parameters))
            {
                if (!"Id".Equals(property.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    dict.Add(property.Name, property.GetValue(parameters));
                }
            }

            if (!dict.ContainsKey("Id")) { dict.Add("Id", record.Id ); }

            return await db.UpdateFieldsAsync<T>(dict) != null;
        }

        public async Task<bool> DeleteAsync(T record)
        {
            using var db = SqlConnectionProvider.CreateConnection();
            db.Open();

            return await db.DeleteAsync(record) == 1;
        }
    }
}
