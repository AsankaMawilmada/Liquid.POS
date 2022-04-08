using System.Threading;
using System.Threading.Tasks;
using Liquid.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Liquid.Persistence.Contexts
{
    public interface ILiquidContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductTransaction> ProductTransactions { get; set; }
        public DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

        public void BeginTransaction();

        public void CommitTransaction();

        public void RollbackTransaction();
        public DatabaseFacade Database { get; }

    }
}
