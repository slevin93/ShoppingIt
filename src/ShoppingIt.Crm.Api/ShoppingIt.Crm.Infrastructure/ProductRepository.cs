using AutoMapper;
using ShoppingIt.Crm.Core.Dto.Products;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return GetArrayAsync<Product, ProductDetails>();
        }
    }
}
