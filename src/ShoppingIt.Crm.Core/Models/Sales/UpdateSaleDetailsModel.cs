// <copyright file="UpdateSaleDetailsModel.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Models.Sales
{
    /// <summary>
    /// Represents sale details to update.
    /// </summary>
    public class UpdateSaleDetailsModel
    {
        /// <summary>
        /// Gets or sets the sale id.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the payment type.
        /// </summary>
        public int PaymentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the sales status id.
        /// </summary>
        public int SalesStatusId { get; set; }
    }
}
