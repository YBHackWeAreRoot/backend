using Microsoft.Extensions.Logging;
using MrParker.DataAccess.Models;
using MrParker.DataAccess.Repositories;
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
        private ProviderRepository repository;

        public ProvidersService(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            repository = new ProviderRepository();
        }

        public async Task<IEnumerable<Provider>> GetProvidersAsync(IEnumerable<Guid> providerIds)
        {
            try
            {
                return await repository.SelectAsync($"Id IN @ProviderId", new { ProviderId = providerIds.ToArray() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Enumerable.Empty<Provider>();
        }

    }
}
