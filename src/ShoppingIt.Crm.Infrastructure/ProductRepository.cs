using AutoMapper;
using ShoppingIt.Crm.Core.Dto.Products;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Infrastructure
{
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        public ProductRepository(ShoppingItContext context, IMapper mapper)
            : base(context, mapper) { }

        public Task<ProductDetails> AddProductAsync(Product product, CancellationToken cancellationToken)
        {
            return AddAsync<Product, ProductDetails>(product, cancellationToken);
        }

        public async Task<DeleteProduct> DeleteProductByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await FindAsync<Product>(id, cancellationToken);

            product.IsActive = false;

            await SaveChangesAsync();

            return new DeleteProduct()
            {
                Id = id
            };
        }

        public Task<ProductDetails> GetProductByIdAsync(int productId, CancellationToken cancellationToken)
        {
            return FirstOrDefaultAsync<Product, ProductDetails>(x => x.ProductId == productId, cancellationToken);
        }

        public Task<ProductDetails> GetProductByNameAsync(string name, CancellationToken cancellationToken)
        {
            return FirstOrDefaultAsync<Product, ProductDetails>(x => x.Name == name, cancellationToken);
        }

        public Task<ProductDetails[]> GetProductsAsync(CancellationToken cancellationToken)
        {
            return GetArrayAsync<Product, ProductDetails>(x => x.IsActive == true, cancellationToken);
        }
    }
}
