using Dapper;
using MrParker.DataAccess.Interfaces;
using MrParker.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        public bool Delete(Customer record)
        {
            return false;
        }

        public bool Insert(Customer record)
        {
            return false;
        }

        public IEnumerable<Customer> Select(string condition = null, object parameters = null)
        {
            using var db = SqlConnectionProvider.CreateConnection();

            return db.Query<Customer>($"SELECT * FROM Customer{(condition != null ? $" WHERE {condition}" : "")};", parameters);
        }

        public int Update(Customer record, string[] cols = null)
        {
            return 0;
        }
    }
}
