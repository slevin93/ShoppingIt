// <copyright file="IProductService.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Services.Products
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShoppingIt.Crm.Core.Dto.Products;
    using ShoppingIt.Crm.Core.Models.Product;

    /// <summary>
    /// Define product business process.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets list of all products from database.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns array of products.</returns>
        Task<ProductDetails[]> GetProductsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Get product by product id.
        /// </summary>
        /// <param name="productId">The productId id.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns product where product id equals provided product id.</returns>
        Task<ProductDetails> GetProductByIdAsync(int productId, CancellationToken cancellationToken);

        /// <summary>
        /// Get product by product name.
        /// </summary>
        /// <param name="name">The product name to search.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns product where product name equals provided product name.</returns>
        Task<ProductDetails> GetProductByNameAsync(string name, CancellationToken cancellationToken);

        /// <summary>
        /// Adds new product to database.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns newly created product.</returns>
        Task<ProductDetails> AddProductAsync(ProductModel product, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes products by product id.
        /// Note: This will not delete the product from the data,
        /// it will only set is active as false.
        /// </summary>
        /// <param name="id">The product id.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns deleted product id as <see cref="DeleteProduct"/>.</returns>
        Task<DeleteProduct> DeleteProductByIdAsync(int id, CancellationToken cancellationToken);
    }
}
