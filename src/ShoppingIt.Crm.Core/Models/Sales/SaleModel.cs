using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Models.Sales
{
    /// <summary>
    /// Defines order details
    /// </summary>
    public class SaleModel
    {
        /// <summary>
        /// The account to add the order to.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// The products assigned to the sale record.
        /// </summary>
        public SaleItemModel[] Items { get; set; }
    }
}
