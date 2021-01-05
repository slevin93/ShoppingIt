using ShoppingIt.Crm.Core.Dto.Sales;
using ShoppingIt.Crm.Core.Models.Sales;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Core.Services.Products;
using ShoppingIt.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<SalesItemDetails> AddItemToSaleAsync(SaleItemModel saleItem)
        {
            // ToDo: Cache products.
            var product = await productService.GetProductByIdAsync(saleItem.ProductId);

            return await salesRepository.AddItemToSaleAsync(new SaleItem()
            {
                ProductId = saleItem.ProductId,
                Price = product.Price,
                Vat = 00.00m,
                Quantity = saleItem.Quantity,
                Total = saleItem.Quantity * product.Price
            });
        }

        public async Task AddItemToSaleAsync(SaleItemModel[] saleItems)
        {
            foreach (var saleItem in saleItems)
            {
                var product = await productService.GetProductByIdAsync(saleItem.ProductId);

                await salesRepository.AddItemToSaleAsync(new SaleItem()
                {
                    ProductId = saleItem.ProductId,
                    Price = product.Price,
                    Vat = 00.00m,
                    Quantity = saleItem.Quantity,
                    Total = saleItem.Quantity * product.Price
                });
            }
        }

        public async Task<SalesDetails> CreateSaleAsync(SaleModel saleModel)
        {
            var newSale = await salesRepository.CreateSaleAsync(new Sale()
            {
                AccountId = saleModel.AccountId,
                TotalItems = saleModel.Items.Length,
                TimeStamp = DateTime.Now
            });

            List<SaleItem> saleItems = new List<SaleItem>();

            foreach (var saleItem in saleModel.Items)
            {
                // ToDo: Cache Products
                var product = await productService.GetProductByIdAsync(saleItem.ProductId);

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

            await salesRepository.AddItemToSaleAsync(saleItems.ToArray());

            var result = await salesRepository.GetSaleByIdAsync(newSale.SaleId);

            result.Items = await salesRepository.GetSalesItemBySaleIdAsync(newSale.SaleId);

            return result;
        }

        public async Task<SalesDetails[]> GetSalesAsync()
        {
            var sales = await salesRepository.GetSalesAsync();

            foreach (var sale in sales)
            {
                sale.Items = await salesRepository.GetSalesItemBySaleIdAsync(sale.SaleId);
            }

            return sales;
        }
    }
}
