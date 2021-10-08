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

        public ProvidersService(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Provider>> GetProviders(IEnumerable<Guid> providerIds)
        {
            ProviderRepository repo = new();

            try
            {
                return await repo.SelectAsync($"ProviderId IN @ProviderId", new { ProviderId = providerIds.ToArray() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

    }
}
