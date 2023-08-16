using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogContainerRepository
    {
        Task<int?> Add(string name);
        Task<CatalogContainer?> Update(int id, string brand);
        Task<bool> Delete(int id);
    }
}
