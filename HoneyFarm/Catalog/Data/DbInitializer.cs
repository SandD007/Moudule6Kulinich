using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.CatalogContainer.Any())
            {
                await context.CatalogContainer.AddRangeAsync(GetPreconfiguredCatalogContainer());

                await context.SaveChangesAsync();
            }

            if (!context.CatalogTypes.Any())
            {
                await context.CatalogTypes.AddRangeAsync(GetPreconfiguredCatalogTypes());

                await context.SaveChangesAsync();
            }

            if (!context.CatalogItems.Any())
            {
                await context.CatalogItems.AddRangeAsync(GetPreconfiguredItems());

                await context.SaveChangesAsync();
            }
        }

        private static IEnumerable<CatalogContainer> GetPreconfiguredCatalogContainer()
        {
            return new List<CatalogContainer>()
                {
                new CatalogContainer() { Name = "250 g" },
                new CatalogContainer() { Name = "500  g" },
                new CatalogContainer() { Name = "1 kg" },
                new CatalogContainer() { Name = "25 kg" }
                };
        }

        private static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
                {
                new CatalogType() { Name = "Acacia" },
                new CatalogType() { Name = "Buckwheat" },
                new CatalogType() { Name = "Linden" },
                new CatalogType() { Name = "Sunflower" }
                };
        }

        private static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>()
                {
                new CatalogItem { CatalogTypeId = 1, CatalogContainerId = 1, AvailableStock = 100, Description = "Good tasty honey", Name = "Summer honey", Price = 19.5M, PictureFileName = "1.png" },
                new CatalogItem { CatalogTypeId = 1, CatalogContainerId = 2, AvailableStock = 100, Description = "Good tasty honey", Name = "Spring honey", Price = 8.50M, PictureFileName = "2.png" },
                new CatalogItem { CatalogTypeId = 1, CatalogContainerId = 3, AvailableStock = 100, Description = "Good tasty honey", Name = "Winter honey", Price = 12, PictureFileName = "3.png" },
                new CatalogItem { CatalogTypeId = 1, CatalogContainerId = 4, AvailableStock = 100, Description = "Good tasty honey", Name = "Winter honey", Price = 12, PictureFileName = "4.png" },
                new CatalogItem { CatalogTypeId = 2, CatalogContainerId = 1, AvailableStock = 100, Description = "Good tasty honey", Name = "Summer honey", Price = 8.5M, PictureFileName = "5.png" },
                new CatalogItem { CatalogTypeId = 2, CatalogContainerId = 2, AvailableStock = 100, Description = "Good tasty honey", Name = "Spring honey", Price = 12, PictureFileName = "6.png" },
                new CatalogItem { CatalogTypeId = 2, CatalogContainerId = 3, AvailableStock = 100, Description = "Good tasty honey", Name = "Winter honey", Price = 12, PictureFileName = "7.png" },
                new CatalogItem { CatalogTypeId = 2, CatalogContainerId = 4, AvailableStock = 100, Description = "Good tasty honey", Name = "Summer honey", Price = 8.5M, PictureFileName = "8.png" },
                new CatalogItem { CatalogTypeId = 3, CatalogContainerId = 1, AvailableStock = 100, Description = "Good tasty honey", Name = "Spring honey", Price = 12, PictureFileName = "9.png" },
                new CatalogItem { CatalogTypeId = 3, CatalogContainerId = 2, AvailableStock = 100, Description = "Good tasty honey", Name = "Winter honey", Price = 12, PictureFileName = "10.png" },
                new CatalogItem { CatalogTypeId = 3, CatalogContainerId = 3, AvailableStock = 100, Description = "Good tasty honey", Name = "Summer honey", Price = 8.5M, PictureFileName = "11.png" },
                new CatalogItem { CatalogTypeId = 3, CatalogContainerId = 4, AvailableStock = 100, Description = "Good tasty honey", Name = "Spring honey", Price = 12, PictureFileName = "12.png" },
                };
        }
    }
}
