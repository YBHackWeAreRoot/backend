using Microsoft.Extensions.Logging;
using MrParker.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.Logic.Customers
{
    public class CustomersService
    {

        private ILogger _logger;

        public CustomersService(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // TODO REFACTOR: Get Customer based on authentication
        public async Task<Customer> GetCurrentCustomer()
        {
            var repo = new DataAccess.Repositories.CustomerRepository();

            try
            {
                return (await repo.SelectAsync($"FirstName = @FirsName AND LastName = @LastName",
                                       new { FirstName = "Peter", LastName = "Parker" })).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }
    }
}
