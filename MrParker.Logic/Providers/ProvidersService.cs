using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.Logic.Providers
{
    public class ProvidersService
    {
        private ILogger _logger;
        private DataAccess.Repositories.ProviderRepository repository;

        public ProvidersService(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            repository = new DataAccess.Repositories.ProviderRepository();
        }

    }
}
