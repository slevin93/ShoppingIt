// <copyright file="PaymentType.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the different payment types.
    /// </summary>
    public class PaymentType
    {
        /// <summary>
        /// Gets or sets the payment type id.
        /// </summary>
        public int PaymentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the payment type name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the payment type description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the payment type.
        /// </summary>
        public ICollection<PaymentType> PaymentTypes { get; set; }
    }
}
