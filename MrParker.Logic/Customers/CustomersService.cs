using Microsoft.Extensions.Logging;
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

        private ILogger _logger;

        public CustomersService(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // TODO REFACTOR: Get Customer based on authentication
        public Task<DataAccess.Models.Customer> GetCurrentCustomer()
        {
            // TODO get from Repository
            return Task.FromResult(mockedCustomer);
        }
    }
}
