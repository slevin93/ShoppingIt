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
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the is active state.
        /// </summary>
        public bool IsActive { get; set; }
    }

    public class ProductValidator : AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();

            RuleFor(x => x.Description).NotNull().NotEmpty();

            RuleFor(x => x.Price).GreaterThanOrEqualTo(00.00m);
        }
    }
}
