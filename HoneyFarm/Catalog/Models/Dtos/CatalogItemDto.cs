using Catalog.Host.Data.Entities;

namespace Catalog.Host.Models.Dtos
{
    public class CatalogItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string PictureUrl { get; set; } = null!;

        public int AvailableStock { get; set; }

        public CatalogType CatalogType { get; set; } = null!;

        public int CatalogTypeId { get; set; }

        public CatalogContainer CatalogContainer { get; set; } = null!;

        public int CatalogContainerId { get; set; }
    }
}
