using System.Threading;
using System.Threading.Tasks;
using Liquid.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Liquid.Persistence.Contexts
{
    public interface ILiquidContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<ProductTransaction> ProductTransactions { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
        DatabaseFacade Database { get; }
    }
}
