using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class CatalogContainerRepository : ICatalogContainerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogContainerRepository> _logger;

        public CatalogContainerRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogContainerRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<int?> Add(string name)
        {
            var item = await _dbContext.AddAsync(new CatalogContainer
            {
                Name = name,
            });

            await _dbContext.SaveChangesAsync();

            return item.Entity.Id;
        }

        public async Task<CatalogContainer?> Update(int id, string name)
        {
            var item = await _dbContext.CatalogContainer.
            FirstOrDefaultAsync(i => i.Id == id);

            if (item != null)
            {
                item.Name = name;
            }

            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _dbContext.CatalogContainer.
            FirstOrDefaultAsync(i => i.Id == id);

            if (item != null)
            {
                _dbContext.CatalogContainer.Remove(item);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                await _dbContext.SaveChangesAsync();
                return false;
            }
        }
    }
}
