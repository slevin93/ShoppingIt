// <copyright file="ProductModel.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Models.Product
{
    using FluentValidation;

    /// <summary>
    /// Defines details for new product.
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Gets or sets product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets sale price,
        /// this will be the price the customer pays.
        /// </summary>
        public decimal SalesPrice { get; set; }

        /// <summary>
        /// Gets or sets the whole sale price,
        /// this will be the price we pay.
        /// </summary>
        public decimal WholePrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether we pay vat on this product.
        /// </summary>
        public bool IsVattable { get; set; }

        /// <summary>
        /// Gets or sets the amount we have in stock.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Gets or sets the link to the whole seller where we buy.
        /// </summary>
        public string WholeSaleLink { get; set; }

        /// <summary>
        /// Gets or sets the linked picture as an array.
        /// </summary>
        public string PictureLink { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is active or not.
        /// </summary>
        public bool IsActive { get; set; }
    }

    /// <summary>
    /// Implement product validation.
    /// </summary>
#pragma warning disable SA1402 // File may only contain a single type
    public class ProductValidator : AbstractValidator<ProductModel>
#pragma warning restore SA1402 // File may only contain a single type
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductValidator"/> class.
        /// </summary>
        public ProductValidator()
        {
            this.RuleFor(x => x.Name).NotNull().NotEmpty();

            this.RuleFor(x => x.Description).NotNull().NotEmpty();

            this.RuleFor(x => x.SalesPrice).GreaterThanOrEqualTo(00.00m);
        }
    }
}
