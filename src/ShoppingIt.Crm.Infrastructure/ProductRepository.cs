using AutoMapper;
using ShoppingIt.Crm.Core.Dto.Products;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Domain;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Infrastructure
{
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        public ProductRepository(ShoppingItContext context, IMapper mapper)
            : base(context, mapper) { }

        public Task<ProductDetails> AddProductAsync(Product product)
        {
            return AddAsync<Product, ProductDetails>(product);
        }

        public async Task<DeleteProduct> DeleteProductByIdAsync(int id)
        {
            var product = await FindAsync<Product>(id);

            product.IsActive = false;

            await SaveChangesAsync();

            return new DeleteProduct()
            {
                Id = id
            };
        }

        public Task<ProductDetails> GetProductByIdAsync(int productId)
        {
            return FirstOrDefaultAsync<Product, ProductDetails>(x => x.ProductId == productId);
        }

        public Task<ProductDetails> GetProductByNameAsync(string name)
        {
            return FirstOrDefaultAsync<Product, ProductDetails>(x => x.Name == name);
        }

        public Task<ProductDetails[]> GetProductsAsync()
        {
            return GetArrayAsync<Product, ProductDetails>(x => x.IsActive == true);
        }
    }
}
