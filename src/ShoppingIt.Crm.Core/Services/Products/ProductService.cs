using ShoppingIt.Crm.Core.Dto.Products;
using ShoppingIt.Crm.Core.Models.Product;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<ProductDetails> AddProductAsync(ProductModel product, CancellationToken cancellationToken)
        {
            var foundProduct = await GetProductByNameAsync(product.Name, cancellationToken);

            if (foundProduct != null)
            {
                throw new Exception("Product already exists.");
            }

            return await productRepository.AddProductAsync(new Product()
            {
                Name = product.Name,
                Description = product.Description,
                IsActive = true,
                SalesPrice = product.SalesPrice,
                WholePrice = product.WholePrice,
                IsVattable = false
            }, cancellationToken);
        }

        public Task<DeleteProduct> DeleteProductByIdAsync(int id, CancellationToken cancellationToken)
        {
            return productRepository.DeleteProductByIdAsync(id, cancellationToken);
        }

        public Task<ProductDetails> GetProductByIdAsync(int productId, CancellationToken cancellationToken)
        {
            return productRepository.GetProductByIdAsync(productId, cancellationToken);
        }

        public Task<ProductDetails> GetProductByNameAsync(string name, CancellationToken cancellationToken)
        {
            return productRepository.GetProductByNameAsync(name, cancellationToken);
        }

        public Task<ProductDetails[]> GetProductsAsync(CancellationToken cancellationToken)
        {
            return productRepository.GetProductsAsync(cancellationToken);
        }
    }
}
