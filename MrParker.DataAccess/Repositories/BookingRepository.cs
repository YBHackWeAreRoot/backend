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
    public class BookingRepository : IRepository<Booking>
    {
        public bool Delete(Booking record)
        {
            return false;
        }

        public bool Insert(Booking record)
        {
            return false;
        }

        public IEnumerable<Booking> Select(string condition = null, object parameters = null)
        {
            using var db = SqlConnectionProvider.CreateConnection();

            return db.Query<Booking>($"SELECT * FROM Booking{(condition != null ? $" WHERE {condition}" : "")};", parameters);
        }

        public int Update(Booking record, string[] cols = null)
        {
            return 0;
        }
    }
}
