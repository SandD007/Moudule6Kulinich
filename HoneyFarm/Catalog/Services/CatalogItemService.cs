using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services.Interfaces;
using Infrastructure.Services;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Services
{
    public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
    {
        private readonly ICatalogItemRepository _catalogItemRepository;

        public CatalogItemService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogItemRepository catalogItemRepository)
            : base(dbContextWrapper, logger)
        {
            _catalogItemRepository = catalogItemRepository;
        }

        public Task<int?> AddAsync(string name, string description, decimal price, int availableStock, int catalogContainerId, int catalogTypeId, string pictureFileName)
        {
            return ExecuteSafeAsync(() => _catalogItemRepository.Add(name, description, price, availableStock, catalogContainerId, catalogTypeId, pictureFileName));
        }

        public Task<CatalogItem?> Update(int id, string name, string description, decimal price, int availableStock, int catalogContainerId, int catalogTypeId, string pictureFileName)
        {
            return ExecuteSafeAsync(() => _catalogItemRepository.Update(id, name, description, price, availableStock, catalogContainerId, catalogTypeId, pictureFileName));
        }

        public Task<bool> Delete(int id)
        {
            return ExecuteSafeAsync(() => _catalogItemRepository.Delete(id));
        }

        public Task<CatalogItem?> GetItemById(int id)
        {
            return ExecuteSafeAsync(() => _catalogItemRepository.GetItemById(id));
        }

        public Task<List<CatalogContainer>> GetItemsContainers()
        {
            return ExecuteSafeAsync(() => _catalogItemRepository.GetItemsContainers());
        }

        public Task<List<CatalogItem>> GetItemsByContainer(int id)
        {
            return ExecuteSafeAsync(() => _catalogItemRepository.GetItemByContainer(id));
        }

        public Task<List<CatalogItem>> GetItemsByType(int id)
        {
            return ExecuteSafeAsync(() => _catalogItemRepository.GetItemByType(id));
        }

        public Task<List<CatalogType>> GetItemsTypes()
        {
            return ExecuteSafeAsync(() => _catalogItemRepository.GetItemsTypes());
        }
    }
}
