using Catalog.Host.Data.Entities;
using Catalog.Host.Data;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogItemRepository
    {
        Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, int? brandFilter, int? typeFilter);
        Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogContainerId, int catalogTypeId, string pictureFileName);
        Task<CatalogItem?> Update(int id, string name, string description, decimal price, int availableStock, int catalogContainerId, int catalogTypeId, string pictureFileName);
        Task<bool> Delete(int id);

        Task<CatalogItem?> GetItemById(int id);
        Task<List<CatalogItem>> GetItemByContainer(int id);
        Task<List<CatalogItem>> GetItemByType(int id);
        Task<List<CatalogContainer>> GetItemsContainers();
        Task<List<CatalogType>> GetItemsTypes();
    }
}
