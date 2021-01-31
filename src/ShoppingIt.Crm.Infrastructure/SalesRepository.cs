using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingIt.Crm.Core.Dto.Sales;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Infrastructure
{
    public class SalesRepository : RepositoryBase, ISalesRepository
    {
        public SalesRepository(ShoppingItContext context, IMapper mapper) 
            : base(context, mapper) { }

        public Task<SalesItemDetails> AddItemToSaleAsync(SaleItem saleItem)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddItemToSaleAsync(SaleItem[] saleItem)
        {
            throw new NotImplementedException();
        }

        public Task<SalesDetails> CreateSaleAsync(Sale sale)
        {
            throw new NotImplementedException();
        }

        public Task<SalesDetails> GetSaleByIdAsync(int saleId)
        {
            throw new NotImplementedException();
        }

        public Task<SalesDetails[]> GetSalesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SalesItemDetails[]> GetSalesItemBySaleIdAsync(int saleId)
        {
            throw new NotImplementedException();
        }
    }
}
