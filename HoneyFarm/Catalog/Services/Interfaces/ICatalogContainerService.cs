using Catalog.Host.Data.Entities;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogContainerService
    {
        Task<int?> Add(string name);
        Task<CatalogContainer?> Update(int id, string brand);
        Task<bool> Delete(int id);
    }
}
