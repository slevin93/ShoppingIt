// <copyright file="ProductRepository.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Infrastructure
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using ShoppingIt.Crm.Core.Dto.Products;
    using ShoppingIt.Crm.Core.Repository;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// Product data access layer.
    /// </summary>
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The ShoppingIt db context.</param>
        /// <param name="mapper">The mapper.</param>
        public ProductRepository(ShoppingItContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        /// <inheritdoc/>
        public Task<ProductDetails> AddProductAsync(Product product, CancellationToken cancellationToken)
        {
            return this.AddAsync<Product, ProductDetails>(product, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<DeleteProduct> DeleteProductByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await this.FindAsync<Product>(id);

            product.IsActive = false;

            await this.SaveChangesAsync(cancellationToken);

            return new DeleteProduct()
            {
                Id = id,
            };
        }

        /// <inheritdoc/>
        public Task<ProductDetails> GetProductByIdAsync(int productId, CancellationToken cancellationToken)
        {
            return this.FirstOrDefaultAsync<Product, ProductDetails>(x => x.ProductId == productId, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ProductDetails> GetProductByNameAsync(string name, CancellationToken cancellationToken)
        {
            return this.FirstOrDefaultAsync<Product, ProductDetails>(x => x.Name == name, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ProductDetails[]> GetProductsAsync(CancellationToken cancellationToken)
        {
            return this.GetArrayAsync<Product, ProductDetails>(x => x.IsActive == true, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ProductDetails> UpdateProductAsync(int productId, Product product, CancellationToken cancellationToken)
        {
            product.ProductId = productId;

            return this.UpdateAsync<Product, ProductDetails>(productId, product, cancellationToken);
        }
    }
}
