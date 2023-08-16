using Catalog.Host.Data.Entities;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogItemService
    {
        Task<int?> AddAsync(string name, string description, decimal price, int availableStock, int catalogContainerdId, int catalogTypeId, string pictureFileName);
        Task<CatalogItem?> Update(int id, string name, string description, decimal price, int availableStock, int catalogCatalogId, int catalogTypeId, string pictureFileName);
        Task<bool> Delete(int id);
        Task<CatalogItem?> GetItemById(int id);
        Task<List<CatalogItem>> GetItemsByContainer(int id);
        Task<List<CatalogItem>> GetItemsByType(int id);

        Task<List<CatalogContainer>> GetItemsContainers();

        Task<List<CatalogType>> GetItemsTypes();
    }
}
