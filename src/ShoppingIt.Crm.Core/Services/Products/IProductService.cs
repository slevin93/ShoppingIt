﻿using ShoppingIt.Crm.Core.Dto.Products;
using ShoppingIt.Crm.Core.Models.Product;
using ShoppingIt.Crm.Domain;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Services.Products
{
    /// <summary>
    /// Define product business process.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets list of all products from database.
        /// </summary>
        /// <returns>Returns array of products.</returns>
        Task<ProductDetails[]> GetProductsAsync();

        /// <summary>
        /// Get product by product id.
        /// </summary>
        /// <param name="productId">The productId id.</param>
        /// <returns>Returns product where product id equals provided product id.</returns>
        Task<ProductDetails> GetProductByIdAsync(int productId);

        /// <summary>
        /// Get product by product name.
        /// </summary>
        /// <param name="name">The product name to search.</param>
        /// <returns>Returns product where product name equals provided product name.</returns>
        Task<ProductDetails> GetProductByNameAsync(string name);

        /// <summary>
        /// Adds new product to database.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <returns>Returns newly created product.</returns>
        Task<ProductDetails> AddProductAsync(ProductModel product);
    }
}