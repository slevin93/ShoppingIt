// <copyright file="OrderStatusDetails.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Dto.Lookup
{
    /// <summary>
    /// Defines the sale status.
    /// </summary>
    public class OrderStatusDetails
    {
        /// <summary>
        /// Gets or sets the sales status id.
        /// </summary>
        public int SalesStatusId { get; set; }

        /// <summary>
        /// Gets or sets the status name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sales status description.
        /// </summary>
        public string Description { get; set; }
    }
}
