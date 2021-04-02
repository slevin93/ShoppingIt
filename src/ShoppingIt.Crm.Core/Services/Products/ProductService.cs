// <copyright file="ProductService.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Services.Products
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
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
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// /// <param name="mapper">The mapper.</param>
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<ProductDetails> AddProductAsync(ProductModel product, CancellationToken cancellationToken)
        {
            var foundProduct = await this.GetProductByNameAsync(product.Name, cancellationToken);

            if (foundProduct != null)
            {
                throw new Exception("Product already exists.");
            }

            return await this.productRepository.AddProductAsync(this.mapper.Map<Product>(product), cancellationToken);
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

        /// <inheritdoc/>
        public Task<ProductDetails> UpdateProductAsync(int productId, ProductModel product, CancellationToken cancellationToken)
        {
            return this.productRepository.UpdateProductAsync(productId, this.mapper.Map<Product>(product), cancellationToken);
        }
    }
}
