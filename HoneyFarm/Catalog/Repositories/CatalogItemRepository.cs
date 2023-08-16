using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class CatalogItemRepository : ICatalogItemRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogItemRepository> _logger;

        public CatalogItemRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogItemRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, int? containerFilter, int? typeFilter)
        {
            IQueryable<CatalogItem> query = _dbContext.CatalogItems;

            if (containerFilter.HasValue)
            {
                query = query.Where(w => w.CatalogContainerId == containerFilter.Value);
            }

            if (typeFilter.HasValue)
            {
                query = query.Where(w => w.CatalogTypeId == typeFilter.Value);
            }

            var totalItems = await query.LongCountAsync();

            var itemsOnPage = await query.OrderBy(c => c.Name)
               .Include(i => i.CatalogContainer)
               .Include(i => i.CatalogType)
               .Skip(pageSize * pageIndex)
               .Take(pageSize)
               .ToListAsync();

            return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
        }

        public async Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogContainerId, int catalogTypeId, string pictureFileName)
        {
            var item1 = new CatalogItem
            {
                CatalogContainerId = catalogContainerId,
                CatalogTypeId = catalogTypeId,
                Description = description,
                Name = name,
                PictureFileName = pictureFileName,
                Price = price,
                AvailableStock = availableStock,
            };
            var item = await _dbContext.AddAsync(item1);

            await _dbContext.SaveChangesAsync();

            return item.Entity.Id;
        }

        public async Task<CatalogItem?> Update(int id, string name, string description, decimal price, int availableStock, int catalogContainerId, int catalogTypeId, string pictureFileName)
        {
            var item = await _dbContext.CatalogItems.
            Include(i => i.CatalogContainer).
            Include(i => i.CatalogType).
            FirstOrDefaultAsync(i => i.Id == id);

            if (item != null)
            {
                item.CatalogContainerId = catalogContainerId;
                item.CatalogTypeId = catalogTypeId;
                item.Description = description;
                item.Name = name;
                item.PictureFileName = pictureFileName;
                item.Price = price;

                _dbContext.Entry(item.CatalogContainer).State = EntityState.Modified;
                _dbContext.Entry(item.CatalogType).State = EntityState.Modified;
            }

            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _dbContext.CatalogItems.
            Include(i => i.CatalogContainer).
            Include(i => i.CatalogType).
            FirstOrDefaultAsync(i => i.Id == id);

            if (item != null)
            {
                _dbContext.CatalogItems.Remove(item);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                await _dbContext.SaveChangesAsync();
                return false;
            }
        }
        public async Task<CatalogItem?> GetItemById(int id)
        {
            var item = await _dbContext.CatalogItems.
                Include(i => i.CatalogContainer).
                Include(i => i.CatalogType).
                FirstOrDefaultAsync(i => i.Id == id);

            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<List<CatalogItem>> GetItemByContainer(int id)
        {
            var item = await _dbContext.CatalogItems.
                Include(i => i.CatalogType).
                Include(i => i.CatalogContainer).
                Where(i => i.CatalogContainerId == id).
                ToListAsync();

            await _dbContext.SaveChangesAsync();
            return item.ToList();
        }

        public async Task<List<CatalogItem>> GetItemByType(int id)
        {
            var item = await _dbContext.CatalogItems.
            Include(i => i.CatalogType).
            Include(i => i.CatalogContainer).
            Where(i => i.CatalogTypeId == id).
            ToListAsync();

            await _dbContext.SaveChangesAsync();
            return item.ToList();
        }

        public async Task<List<CatalogContainer>> GetItemsContainers()
        {
            var item = await _dbContext.CatalogContainer.
            ToListAsync();

            await _dbContext.SaveChangesAsync();
            return item.ToList();
        }

        public async Task<List<CatalogType>> GetItemsTypes()
        {
            var item = await _dbContext.CatalogTypes.
            ToListAsync();

            await _dbContext.SaveChangesAsync();
            return item.ToList();
        }
    }
}
