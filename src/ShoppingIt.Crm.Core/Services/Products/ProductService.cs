// <copyright file="ProductService.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Services.Products
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ShoppingIt.Crm.Core.Dto.Products;
    using ShoppingIt.Crm.Core.Models.Product;
    using ShoppingIt.Crm.Core.Repository;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// Implements product service operations.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        /// <inheritdoc/>
        public async Task<ProductDetails> AddProductAsync(ProductModel product, CancellationToken cancellationToken)
        {
            var foundProduct = await this.GetProductByNameAsync(product.Name, cancellationToken);

            if (foundProduct != null)
            {
                throw new Exception("Product already exists.");
            }

            return await this.productRepository.AddProductAsync(
                new Product()
                {
                    Name = product.Name,
                    Description = product.Description,
                    IsActive = true,
                    SalesPrice = product.SalesPrice,
                    WholePrice = product.WholePrice,
                    IsVattable = false,
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public Task<DeleteProduct> DeleteProductByIdAsync(int id, CancellationToken cancellationToken)
        {
            return this.productRepository.DeleteProductByIdAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ProductDetails> GetProductByIdAsync(int productId, CancellationToken cancellationToken)
        {
            return this.productRepository.GetProductByIdAsync(productId, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ProductDetails> GetProductByNameAsync(string name, CancellationToken cancellationToken)
        {
            return this.productRepository.GetProductByNameAsync(name, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ProductDetails[]> GetProductsAsync(CancellationToken cancellationToken)
        {
            return this.productRepository.GetProductsAsync(cancellationToken);
        }
    }
}
