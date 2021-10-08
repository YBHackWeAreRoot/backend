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

        public async Task<bool> UpdateAsync(T record, string[] columns = null)
        {
            using var db = SqlConnectionProvider.CreateConnection();
            db.Open();

            // Add Id-column and all columns that should be to updated to the Dictionary.
            Dictionary<string, object> dict = new();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(record))
            {
                if ("Id".Equals(property.Name, StringComparison.InvariantCultureIgnoreCase) ||
                    columns.Any(c => c.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    dict.Add(property.Name, property.GetValue(record));
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
