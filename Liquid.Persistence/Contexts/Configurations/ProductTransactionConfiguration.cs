using Liquid.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Liquid.Persistence.Contexts.Configurations
{
    public class ProductTransactionConfiguration : IEntityTypeConfiguration<ProductTransaction>
    {
        public void Configure(EntityTypeBuilder<ProductTransaction> builder)
        {
            builder.ToTable(nameof(ProductTransaction));
            builder.Property(x => x.ProductOrderNumber).HasColumnType("nvarchar(70)");
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.PurchasedPrice).IsRequired();
            builder.Property(x => x.Type).HasColumnType("smallint").IsRequired();

            builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();
            builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();
        }
    }
}