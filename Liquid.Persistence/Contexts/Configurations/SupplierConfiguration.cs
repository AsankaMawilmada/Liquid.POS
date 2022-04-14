using Liquid.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Liquid.Persistence.Contexts.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable(nameof(Supplier));
            builder.Property(x => x.SupplierGuId).HasColumnType("UniqueIdentifier").HasDefaultValueSql("NEWID()").IsRequired();
            builder.Property(x => x.Name).HasColumnType("nvarchar(75)").IsRequired();
            builder.Property(x => x.Phone).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.AddressLine1).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.AddressLine2).HasColumnType("nvarchar(50)");
            builder.Property(x => x.City).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.State).HasColumnType("nvarchar(50)");
            builder.Property(x => x.PostalCode).HasColumnType("nvarchar(15)").IsRequired();

            builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();
            builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();
        }
    }
}