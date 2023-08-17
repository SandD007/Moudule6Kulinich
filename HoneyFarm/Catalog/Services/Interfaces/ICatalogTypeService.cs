using Catalog.Host.Data.Entities;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogTypeService
    {
        Task<int?> Add(string name);
        Task<CatalogType?> Update(int id, string name);
        Task<bool> Delete(int id);
    }
}
