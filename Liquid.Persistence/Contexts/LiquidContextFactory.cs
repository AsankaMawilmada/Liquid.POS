using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Liquid.Persistence.Contexts
{
    public class LiquidContextFactory : IDesignTimeDbContextFactory<LiquidContext>
    {
        public LiquidContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LiquidContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Liquid;Trusted_Connection=True;MultipleActiveResultSets=True");

            return new LiquidContext(optionsBuilder.Options);
        }
    }
}
