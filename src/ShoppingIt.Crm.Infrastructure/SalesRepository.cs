// <copyright file="SalesRepository.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Infrastructure
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using ShoppingIt.Crm.Core.Dto.Sales;
    using ShoppingIt.Crm.Core.Models.Sales;
    using ShoppingIt.Crm.Core.Repository;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// Sales data repository.
    /// </summary>
    public class SalesRepository : RepositoryBase, ISalesRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRepository"/> class.
        /// </summary>
        /// <param name="context">The ShoppingIt dbcontext.</param>
        /// <param name="mapper">The IMapper.</param>
        public SalesRepository(ShoppingItContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        /// <inheritdoc/>
        public Task<SalesItemDetails> AddItemToSaleAsync(SaleItem saleItem, CancellationToken cancellationToken)
        {
            return this.AddAsync<SaleItem, SalesItemDetails>(saleItem, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<int> AddItemToSaleAsync(SaleItem[] saleItem, CancellationToken cancellationToken)
        {
            return this.AddRangeAsync(saleItem, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<SalesDetails> CreateSaleAsync(Sale sale, CancellationToken cancellationToken)
        {
            return this.AddAsync<Sale, SalesDetails>(sale, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<SalesDetails> GetSaleByIdAsync(int saleId, CancellationToken cancellationToken)
        {
            return this.FirstOrDefaultAsync<Sale, SalesDetails>(x => x.SaleId == saleId, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<SalesItemDetails> GetSaleItemBySaleItemIdAsync(int saleItemId, CancellationToken cancellationToken)
        {
            return this.FirstOrDefaultAsync<SaleItem, SalesItemDetails>(x => x.SaleItemId == saleItemId, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<SalesDetails[]> GetSalesAsync(CancellationToken cancellationToken)
        {
            return this.GetArrayAsync<Sale, SalesDetails>(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<SalesItemDetails[]> GetSalesItemBySaleIdAsync(int saleId, CancellationToken cancellationToken)
        {
            return this.GetArrayAsync<SaleItem, SalesItemDetails>(x => x.SaleId == saleId, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<SalesDetails> UpdateSaleAsync(int saleId, Sale sale, CancellationToken cancellationToken)
        {
            sale.SaleId = saleId;

            return this.UpdateAsync<Sale, SalesDetails>(saleId, sale, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<SalesItemDetails> UpdateSaleItemAsync(int saleItemId, SaleItem saleItem, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
