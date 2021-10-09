using Dapper;
using MrParker.DataAccess.Helpers;
using MrParker.DataAccess.Interfaces;
using MrParker.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Repositories
{

    public class BookingRepository : BaseRepository<Booking>
    {

        public async Task<bool> DeleteByConditionAsync(string condition, object parameters)
        {
            using var db = SqlConnectionProvider.CreateConnection();
            db.Open();

            await db.DeleteListAsync<Booking>(condition, parameters);
            return true;
        }

    }
}
