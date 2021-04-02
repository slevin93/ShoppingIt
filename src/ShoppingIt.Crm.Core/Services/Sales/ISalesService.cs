// <copyright file="ISalesService.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Services.Sales
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShoppingIt.Crm.Core.Dto.Sales;
    using ShoppingIt.Crm.Core.Models.Sales;

    /// <summary>
    /// Interface defines sales service operations.
    /// </summary>
    public interface ISalesService
    {
        /// <summary>
        /// Get all sales.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns array of sales.</returns>
        Task<SalesDetails[]> GetSalesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Create new sale record.
        /// </summary>
        /// <param name="sale">Sale details.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns newrly created sale record.</returns>
        Task<SalesDetails> CreateSaleAsync(SaleModel sale, CancellationToken cancellationToken);

        /// <summary>
        /// Add item record to sale.
        /// </summary>
        /// <param name="saleItem">Sale item to add.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns newly created sale item.</returns>
        Task<SalesItemDetails> AddItemToSaleAsync(SaleItemModel saleItem, CancellationToken cancellationToken);

        /// <summary>
        /// Gets sales item from the provided sale id.
        /// </summary>
        /// <param name="saleId">The sale id.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns an array of sale items where sale id equals provided sale id.</returns>
        Task<SalesItemDetails[]> GetSalesItemBySaleIdAsync(int saleId, CancellationToken cancellationToken);

        /// <summary>
        /// Add item record to sale.
        /// </summary>
        /// <param name="saleItems">List of sale item to add.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddItemToSaleAsync(SaleItemModel[] saleItems, CancellationToken cancellationToken);

        /// <summary>
        /// Get sale item by sale id.
        /// </summary>
        /// <param name="id">The sale item id to get.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Return sales details.</returns>
        Task<SalesDetails> GetSaleItemByIdAsync(int id, CancellationToken cancellationToken);
    }
}
