using ShoppingIt.Crm.Core.Dto.Sales;
using ShoppingIt.Crm.Core.Models.Sales;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Core.Services.Products;
using ShoppingIt.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Services.Sales
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository salesRepository;
        private readonly IProductService productService;
        
        public SalesService(ISalesRepository salesRepository, IProductService productService)
        {
            this.salesRepository = salesRepository;
            this.productService = productService;
        }

        public async Task<SalesItemDetails> AddItemToSaleAsync(SaleItemModel saleItem, CancellationToken cancellationToken)
        {
            // ToDo: Cache products.
            var product = await productService.GetProductByIdAsync(saleItem.ProductId, cancellationToken);

            return await salesRepository.AddItemToSaleAsync(new SaleItem()
            {
                ProductId = saleItem.ProductId,
                Price = product.Price,
                Vat = 00.00m,
                Quantity = saleItem.Quantity,
                Total = saleItem.Quantity * product.Price
            }, cancellationToken);
        }

        public async Task AddItemToSaleAsync(SaleItemModel[] saleItems, CancellationToken cancellationToken)
        {
            foreach (var saleItem in saleItems)
            {
                var product = await productService.GetProductByIdAsync(saleItem.ProductId, cancellationToken);

                await salesRepository.AddItemToSaleAsync(new SaleItem()
                {
                    ProductId = saleItem.ProductId,
                    Price = product.Price,
                    Vat = 00.00m,
                    Quantity = saleItem.Quantity,
                    Total = saleItem.Quantity * product.Price
                }, cancellationToken);
            }
        }

        public async Task<SalesDetails> CreateSaleAsync(SaleModel saleModel, CancellationToken cancellationToken)
        {
            var newSale = await salesRepository.CreateSaleAsync(new Sale()
            {
                AccountId = saleModel.AccountId,
                PaymentTypeId = saleModel.PaymentTypeId,
                SalesStatusId = saleModel.SaleStatusId,
                TotalItems = saleModel.Items.Length,
                TimeStamp = DateTime.Now
            }, cancellationToken);

            List<SaleItem> saleItems = new List<SaleItem>();

            foreach (var saleItem in saleModel.Items)
            {
                var product = await productService.GetProductByIdAsync(saleItem.ProductId, cancellationToken);

                saleItems.Add(new SaleItem()
                {
                    SaleId = newSale.SaleId,
                    ProductId = product.ProductId,
                    Price = product.Price,
                    Vat = 00.00m,
                    Quantity = saleItem.Quantity,
                    Total = saleItem.Quantity * product.Price
                });
            }

            await salesRepository.AddItemToSaleAsync(saleItems.ToArray(), cancellationToken);

            var result = await salesRepository.GetSaleByIdAsync(newSale.SaleId, cancellationToken);

            return result;
        }

        public Task<SalesDetails> GetSaleItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return salesRepository.GetSaleByIdAsync(id, cancellationToken);
        }

        public Task<SalesDetails[]> GetSalesAsync(CancellationToken cancellationToken)
        {
            return salesRepository.GetSalesAsync(cancellationToken);
        }

        public Task<SalesItemDetails[]> GetSalesItemBySaleIdAsync(int saleId, CancellationToken cancellationToken)
        {
            return salesRepository.GetSalesItemBySaleIdAsync(saleId, cancellationToken);
        }
    }
}
