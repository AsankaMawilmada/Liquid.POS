using Liquid.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Liquid.Persistence.Contexts.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.Property(x => x.UserGuId).HasColumnType("UniqueIdentifier").HasDefaultValueSql("NEWID()").IsRequired();
            builder.Property(x => x.Hash).HasColumnType("varbinary(MAX)").IsRequired();
            builder.Property(x => x.Salt).HasColumnType("varbinary(MAX)").IsRequired();
            builder.Property(x => x.FirstName).HasColumnType("nvarchar(75)").IsRequired();
            builder.Property(x => x.LastName).HasColumnType("nvarchar(75)").IsRequired();
            builder.Property(x => x.DateOfBirth).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Username).HasColumnType("nvarchar(75)").IsRequired();
            builder.Property(x => x.Role).HasColumnType("smallint").IsRequired();
            builder.Property(x => x.Active).HasColumnType("bit").IsRequired();

            builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();
            builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();
        }
    }
}