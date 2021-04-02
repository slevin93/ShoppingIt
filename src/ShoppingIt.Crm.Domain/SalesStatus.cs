// <copyright file="SalesStatus.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the sale status.
    /// </summary>
    public class SalesStatus
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

        /// <summary>
        /// Gets or sets the sales items.
        /// </summary>
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
