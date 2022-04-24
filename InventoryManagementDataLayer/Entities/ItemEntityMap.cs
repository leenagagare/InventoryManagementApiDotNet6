
using InventoryManagementDataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementDataLayer.Entities
{
    class ItemEntityMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product_master");
            builder.Property(t => t.ProductCode).HasColumnName("pm_product_code").UseIdentityColumn();
            builder.Property(t => t.Name).HasColumnName("pm_name");
            builder.Property(t => t.ProductDescription).HasColumnName("pm_description");
            builder.Property(t => t.Price).HasColumnName("pm_price");
        }
    }
}
