using Catalog.Host.Data;
using Infrastructure.Services.Interfaces;
using Infrastructure.Services;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogContainerService : BaseDataService<ApplicationDbContext>, ICatalogContainerService
    {
        private readonly ICatalogContainerRepository _catalogContainerRepository;

        public CatalogContainerService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogContainerRepository catalogContainerRepository)
            : base(dbContextWrapper, logger)
        {
            _catalogContainerRepository = catalogContainerRepository;
        }

        public Task<int?> Add(string name)
        {
            return ExecuteSafeAsync(() => _catalogContainerRepository.Add(name));
        }

        public Task<bool> Delete(int id)
        {
            return ExecuteSafeAsync(() => _catalogContainerRepository.Delete(id));
        }

        public Task<CatalogContainer?> Update(int id, string brand)
        {
            return ExecuteSafeAsync(() => _catalogContainerRepository.Update(id, brand));
        }
    }
}
