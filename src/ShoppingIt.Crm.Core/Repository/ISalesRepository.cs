// <copyright file="ISalesRepository.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Repository
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShoppingIt.Crm.Core.Dto.Sales;
    using ShoppingIt.Crm.Core.Models.Sales;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// Defines sales data access.
    /// </summary>
    public interface ISalesRepository
    {
        /// <summary>
        /// Get all sales.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns array of sales.</returns>
        Task<SalesDetails[]> GetSalesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Get sale by id.
        /// </summary>
        /// <param name="saleId">The id for the sale to return.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns sale details where sale id equals sale id.</returns>
        Task<SalesDetails> GetSaleByIdAsync(int saleId, CancellationToken cancellationToken);

        /// <summary>
        /// Create new sale record.
        /// </summary>
        /// <param name="sale">Sale details.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns newrly created sale record.</returns>
        Task<SalesDetails> CreateSaleAsync(Sale sale, CancellationToken cancellationToken);

        /// <summary>
        /// Add item record to sale.
        /// </summary>
        /// <param name="saleItem">Sale item to add.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns newly created sale item.</returns>
        Task<SalesItemDetails> AddItemToSaleAsync(SaleItem saleItem, CancellationToken cancellationToken);

        /// <summary>
        /// Add item record to sale.
        /// </summary>
        /// <param name="saleItem">List of sale item to add.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns total number of rows added.</returns>
        Task<int> AddItemToSaleAsync(SaleItem[] saleItem, CancellationToken cancellationToken);

        /// <summary>
        /// Gets sales item from the provided sale id.
        /// </summary>
        /// <param name="saleId">The sale id.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns an array of sale items where sale id equals provided sale id.</returns>
        Task<SalesItemDetails[]> GetSalesItemBySaleIdAsync(int saleId, CancellationToken cancellationToken);

        /// <summary>
        /// Update sale details with new values.
        /// </summary>
        /// <param name="saleId">The sale id.</param>
        /// <param name="sale">The new sale value.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns newly updates sale details.</returns>
        Task<SalesDetails> UpdateSaleAsync(int saleId, Sale sale, CancellationToken cancellationToken);

        /// <summary>
        /// Update sale items with new values.
        /// </summary>
        /// <param name="saleItemId">The sale item id.</param>
        /// <param name="saleItem">The new sale item.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns newly updates sale item.</returns>
        Task<SalesItemDetails> UpdateSaleItemAsync(int saleItemId, SaleItem saleItem, CancellationToken cancellationToken);

        /// <summary>
        /// Gets sale item where sale item id equals provided sale item.
        /// </summary>
        /// <param name="saleItemId">The sale item.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns sale item where sale item id equals provided sales item.</returns>
        Task<SalesItemDetails> GetSaleItemBySaleItemIdAsync(int saleItemId, CancellationToken cancellationToken);
    }
}
