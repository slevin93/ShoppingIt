using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Domain
{
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

        public ICollection<PaymentType> PaymentTypes { get; set; }
    }
}
