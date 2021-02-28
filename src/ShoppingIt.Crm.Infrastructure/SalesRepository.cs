using AutoMapper;
using ShoppingIt.Crm.Core.Dto.Sales;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Domain;
using System.Threading;
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

        public Task<SalesItemDetails> AddItemToSaleAsync(SaleItem saleItem, CancellationToken cancellationToken)
        {
            return AddAsync<SaleItem, SalesItemDetails>(saleItem, cancellationToken);
        }

        public Task<int> AddItemToSaleAsync(SaleItem[] saleItem, CancellationToken cancellationToken)
        {
            return AddRangeAsync(saleItem, cancellationToken);
        }

        public Task<SalesDetails> CreateSaleAsync(Sale sale, CancellationToken cancellationToken)
        {
            return AddAsync<Sale, SalesDetails>(sale, cancellationToken);
        }

        public Task<SalesDetails> GetSaleByIdAsync(int saleId, CancellationToken cancellationToken)
        {
            return FirstOrDefaultAsync<Sale, SalesDetails>(x => x.SaleId == saleId, cancellationToken);
        }

        public Task<SalesDetails[]> GetSalesAsync(CancellationToken cancellationToken)
        {
            return GetArrayAsync<Sale, SalesDetails>(cancellationToken);
        }

        public Task<SalesItemDetails[]> GetSalesItemBySaleIdAsync(int saleId, CancellationToken cancellationToken)
        {
            return GetArrayAsync<SaleItem, SalesItemDetails>(x => x.SaleId == saleId, cancellationToken);
        }
    }
}
