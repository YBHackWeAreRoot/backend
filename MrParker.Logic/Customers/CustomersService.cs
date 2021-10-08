using Microsoft.Extensions.Logging;
using MrParker.DataAccess.Models;
using MrParker.DataAccess.Repositories;
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
        private CustomerRepository repository;

        public CustomersService(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            repository = new CustomerRepository();
        }

        // TODO REFACTOR: Get Customer based on authentication
        public async Task<Customer> GetCurrentCustomer()
        {
            try
            {
                return (await repository.SelectAsync($"FirstName = @FirstName AND LastName = @LastName",
                                                     new { FirstName = "Peter", LastName = "Parker" })).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get current Customer");
            }
            return null;
        }
    }
}
