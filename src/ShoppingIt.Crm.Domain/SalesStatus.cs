using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Domain
{
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

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
