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
            builder.Property(x => x.UserGuId).HasColumnType("UniqueIdentifier").HasDefaultValueSql("NEWID()");
            builder.Property(x => x.Hash).HasColumnType("TEXT");
            builder.Property(x => x.Salt).HasColumnType("TEXT");
        }
    }

}