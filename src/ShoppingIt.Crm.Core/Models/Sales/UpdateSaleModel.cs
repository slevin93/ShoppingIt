// <copyright file="UpdateSaleModel.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Models.Sales
{
    /// <summary>
    /// Define sale order and items to update.
    /// </summary>
    public class UpdateSaleModel
    {
        /// <summary>
        /// Gets or sets the new sale value.
        /// </summary>
        public UpdateSaleDetailsModel Sale { get; set; }

        /// <summary>
        /// Gets or sets the new sale items list.
        /// </summary>
        public UpdateSaleItemModel[] SaleItems { get; set; }
    }
}
