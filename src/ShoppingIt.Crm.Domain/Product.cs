using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingIt.Crm.Domain
{
    /// <summary>
    /// Gets or sets products.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets product id.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets price.
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// Gets or sets if the product is active or not.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
