using ShoppingIt.Crm.Core.Dto.Sales;
using ShoppingIt.Crm.Core.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Services.Sales
{
    public interface ISalesService
    {
        /// <summary>
        /// Get all sales.
        /// </summary>
        /// <returns>Returns array of sales.</returns>
        Task<SalesDetails[]> GetSalesAsync();

        /// <summary>
        /// Create new sale record.
        /// </summary>
        /// <param name="sale">Sale details.</param>
        /// <returns>Returns newrly created sale record.</returns>
        Task<SalesDetails> CreateSaleAsync(SaleModel sale);

        /// <summary>
        /// Add item record to sale.
        /// </summary>
        /// <param name="saleItem">Sale item to add.</param>
        /// <returns>Returns newly created sale item.</returns>
        Task<SalesItemDetails> AddItemToSaleAsync(SaleItemModel saleItem);

        /// <summary>
        /// Gets sales item from the provided sale id.
        /// </summary>
        /// <param name="saleId">The sale id.</param>
        /// <returns>Returns an array of sale items where sale id equals provided sale id.</returns>
        Task<SalesItemDetails[]> GetSalesItemBySaleIdAsync(int saleId);

        /// <summary>
        /// Add item record to sale.
        /// </summary>
        /// <param name="saleItem">List of sale item to add.</param>
        Task AddItemToSaleAsync(SaleItemModel[] saleItems);

        /// <summary>
        /// Get sale item by sale id.
        /// </summary>
        /// <returns>Return sales details.</returns>
        Task<SalesDetails> GetSaleItemByIdAsync(int id);
    }
}
