using Liquid.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Liquid.Persistence.Contexts.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));
            builder.Property(x => x.CategoryGuId).HasColumnType("UniqueIdentifier").HasDefaultValueSql("NEWID()").IsRequired();
            builder.Property(x => x.Name).HasColumnType("nvarchar(255)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(1000)");

            builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();
            builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();
        }
    }
}