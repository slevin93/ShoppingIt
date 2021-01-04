using Microsoft.EntityFrameworkCore;
using ShoppingIt.Crm.Domain;

namespace ShoppingIt.Crm.Infrastructure
{
    public class ShoppingItContext : DbContext
    {
        public ShoppingItContext(DbContextOptions<ShoppingItContext> options)
            : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }

        public DbSet<AssignedAccountType> AssignedAccountType { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sale { get; set; }

        public DbSet<SaleItem> SaleItem { get; set; }
    }
}
