// <copyright file="PaymentTypeDetails.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Dto.Lookup
{
    /// <summary>
    /// Defines the payment types.
    /// </summary>
    public class PaymentTypeDetails
    {
        /// <summary>
        /// Gets or sets the payment type id.
        /// </summary>
        public int PaymentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the payment name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the payment description.
        /// </summary>
        public string Description { get; set; }
    }
}
