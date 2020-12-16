using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingIt.Crm.Domain
{
    /// <summary>
    /// Defines sales.
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// Gets or sets the sale id.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets time stamp.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets account.
        /// </summary>
        public virtual Account Account { get; set; }
    }
}
