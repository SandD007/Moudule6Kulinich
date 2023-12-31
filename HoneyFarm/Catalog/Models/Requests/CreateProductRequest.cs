﻿namespace Catalog.Host.Models.Requests
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string PictureFileName { get; set; } = null!;

        public int CatalogTypeId { get; set; }

        public int CatalogContainerId { get; set; }

        public int AvailableStock { get; set; }
    }
}
