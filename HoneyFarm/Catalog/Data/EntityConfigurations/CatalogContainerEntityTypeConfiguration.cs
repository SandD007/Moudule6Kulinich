using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations
{
    public class CatalogContainerEntityTypeConfiguration
        : IEntityTypeConfiguration<CatalogContainer>
    {
        public void Configure(EntityTypeBuilder<CatalogContainer> builder)
        {
            builder.ToTable("CatalogContainer");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .UseHiLo("catalog_container_hilo")
                .IsRequired();

            builder.Property(cb => cb.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
