using ShoppingIt.Crm.Core.Dto.Sales;
using ShoppingIt.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Repository
{
    /// <summary>
    /// Defines sales data access.
    /// </summary>
    public interface ISalesRepository
    {
        /// <summary>
        /// Get all sales.
        /// </summary>
        /// <returns>Returns array of sales.</returns>
        Task<SalesDetails[]> GetSalesAsync();

        /// <summary>
        /// Get sale by id.
        /// </summary>
        /// <param name="saleId">The id for the sale to return.</param>
        /// <returns>Returns sale details where sale id equals sale id.</returns>
        Task<SalesDetails> GetSaleByIdAsync(int saleId);

        /// <summary>
        /// Create new sale record.
        /// </summary>
        /// <param name="sale">Sale details.</param>
        /// <returns>Returns newrly created sale record.</returns>
        Task<SalesDetails> CreateSaleAsync(Sale sale);

        /// <summary>
        /// Add item record to sale.
        /// </summary>
        /// <param name="saleItem">Sale item to add.</param>
        /// <returns>Returns newly created sale item.</returns>
        Task<SalesItemDetails> AddItemToSaleAsync(SaleItem saleItem);

        /// <summary>
        /// Add item record to sale.
        /// </summary>
        /// <param name="saleItem">List of sale item to add.</param>
        /// <returns>Returns total number of rows added.</returns>
        Task<int> AddItemToSaleAsync(SaleItem[] saleItem);

        /// <summary>
        /// Gets sales item from the provided sale id.
        /// </summary>
        /// <param name="saleId">The sale id.</param>
        /// <returns>Returns an array of sale items where sale id equals provided sale id.</returns>
        Task<SalesItemDetails[]> GetSalesItemBySaleIdAsync(int saleId);
    }
}
