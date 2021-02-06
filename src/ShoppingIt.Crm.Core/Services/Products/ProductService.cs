using ShoppingIt.Crm.Core.Dto.Products;
using ShoppingIt.Crm.Core.Models.Product;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Domain;
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

        public async Task<ProductDetails> AddProductAsync(ProductModel product)
        {
            var foundProduct = await GetProductByNameAsync(product.Name);

            if (foundProduct != null)
            {
                return null;
            }

            return await productRepository.AddProductAsync(new Product()
            {
                Name = product.Name,
                Description = product.Description,
                IsActive = true,
                SalesPrice = product.SalesPrice,
                WholePrice = product.WholePrice,
                IsVattable = false
            });
        }

        public Task<DeleteProduct> DeleteProductByIdAsync(int id)
        {
            return productRepository.DeleteProductByIdAsync(id);
        }

        public Task<ProductDetails> GetProductByIdAsync(int productId)
        {
            return productRepository.GetProductByIdAsync(productId);
        }

        public Task<ProductDetails> GetProductByNameAsync(string name)
        {
            return productRepository.GetProductByNameAsync(name);
        }

        public Task<ProductDetails[]> GetProductsAsync()
        {
            return productRepository.GetProductsAsync();
        }
    }
}
