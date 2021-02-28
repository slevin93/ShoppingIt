using AutoMapper;
using ShoppingIt.Crm.Core.Dto.Sales;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Domain;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Infrastructure
{
    public class SalesRepository : RepositoryBase, ISalesRepository
    {
        public ShoppingItContext context1;

        public SalesRepository(ShoppingItContext context, IMapper mapper) 
            : base(context, mapper) 
        {
            this.context1 = context;
        }

        public Task<SalesItemDetails> AddItemToSaleAsync(SaleItem saleItem)
        {
            return AddAsync<SaleItem, SalesItemDetails>(saleItem);
        }

        public Task<int> AddItemToSaleAsync(SaleItem[] saleItem)
        {
            return AddRangeAsync(saleItem);
        }

        public Task<SalesDetails> CreateSaleAsync(Sale sale)
        {
            return AddAsync<Sale, SalesDetails>(sale);
        }

        public Task<SalesDetails> GetSaleByIdAsync(int saleId)
        {
            return FirstOrDefaultAsync<Sale, SalesDetails>(x => x.SaleId == saleId);
        }

        public Task<SalesDetails[]> GetSalesAsync()
        {
            return GetArrayAsync<Sale, SalesDetails>();
        }

        public Task<SalesItemDetails[]> GetSalesItemBySaleIdAsync(int saleId)
        {
            return GetArrayAsync<SaleItem, SalesItemDetails>(x => x.SaleId == saleId);
        }
    }
}
