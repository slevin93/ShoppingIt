using FluentValidation;

namespace ShoppingIt.Crm.Core.Models.Product
{
    /// <summary>
    /// Defines details for new product.
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal SalesPrice { get; set; }

        /// <summary>
        /// Gets or sets the whole sale price,
        /// this will be the price we pay.
        /// </summary>
        public decimal WholePrice { get; set; }

        /// <summary>
        /// Gets or sets the link to the whole seller where we buy.
        /// </summary>
        public string WholeSaleLink { get; set; }
    }

    public class ProductValidator : AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();

            RuleFor(x => x.Description).NotNull().NotEmpty();

            RuleFor(x => x.SalesPrice).GreaterThanOrEqualTo(00.00m);
        }
    }
}
