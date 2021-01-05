using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Models.Sales
{
    public class SaleItemModel
    {
        /// <summary>
        /// Gets or sets the product id to add to sale.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The amount of products for order.
        /// </summary>
        public int Quantity { get; set; }
    }
}
