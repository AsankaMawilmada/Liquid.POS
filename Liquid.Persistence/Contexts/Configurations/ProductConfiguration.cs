using Liquid.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Liquid.Persistence.Contexts.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.Property(x => x.ProductGuId).HasColumnType("UniqueIdentifier").HasDefaultValueSql("NEWID()").IsRequired();
            builder.Property(x => x.Name).HasColumnType("nvarchar(70)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.PurchasedPrice).IsRequired();
            builder.Property(x => x.RegularPrice).IsRequired();

            builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();
            builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();
        }
    }
}