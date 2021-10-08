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
        // TODO REFACTOR: Use real customers instead of Mock-Data
        private readonly DataAccess.Models.Customer mockedCustomer = new()
        {
            Id = Guid.Parse("0ade866e-eefa-43bd-bc1c-fc8e3932c4ae"),
            FirstName = "Hans",
            LastName = "Muster",
        };

        // TODO REFACTOR: Get Customer based on authentication
        public Task<Customer> GetCurrentCustomer()
        {
            var repo = new DataAccess.Repositories.CustomerRepository();

            try
            {
                return Task.FromResult(repo.SelectAsync($"FirstName = @FirsName AND LastName = @LastName",
                                       new { FirstName = "Peter", LastName = "Parker" }).Result.FirstOrDefault());
            }
            catch (Exception ex)
            {

            }

            // TODO get from Repository
            return Task.FromResult(mockedCustomer);
        }
    }
}
