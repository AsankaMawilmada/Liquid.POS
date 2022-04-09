using Liquid.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Liquid.Persistence.Contexts.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));
            builder.Property(x => x.CustomerGuId).HasColumnType("UniqueIdentifier").HasDefaultValueSql("NEWID()");
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.Phone).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.AddressLine1).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.AddressLine2).HasColumnType("nvarchar(50)");
            builder.Property(x => x.City).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.State).HasColumnType("nvarchar(50)");
            builder.Property(x => x.PostalCode).HasColumnType("nvarchar(15)").IsRequired();
        }
    }
}