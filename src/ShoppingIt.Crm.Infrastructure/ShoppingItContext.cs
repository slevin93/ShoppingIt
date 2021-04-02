// <copyright file="ShoppingItContext.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// ShoppingIt database context.
    /// </summary>
    public class ShoppingItContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingItContext"/> class.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public ShoppingItContext(DbContextOptions<ShoppingItContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the accounts dbset.
        /// </summary>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Gets or sets the account types dbset.
        /// </summary>
        public DbSet<AccountType> AccountTypes { get; set; }

        /// <summary>
        /// Gets or sets the assigned account type dbset.
        /// </summary>
        public DbSet<AssignedAccountType> AssignedAccountType { get; set; }

        /// <summary>
        /// Gets or sets the products dbset.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the sale dbset.
        /// </summary>
        public DbSet<Sale> Sale { get; set; }

        /// <summary>
        /// Gets or sets the sale item dbset.
        /// </summary>
        public DbSet<SaleItem> SaleItem { get; set; }
    }
}
