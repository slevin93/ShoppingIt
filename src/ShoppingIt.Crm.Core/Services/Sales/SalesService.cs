// <copyright file="SalesService.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Services.Sales
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ShoppingIt.Crm.Core.Dto.Sales;
    using ShoppingIt.Crm.Core.Models.Sales;
    using ShoppingIt.Crm.Core.Repository;
    using ShoppingIt.Crm.Core.Services.Products;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// The sales service.
    /// </summary>
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository salesRepository;
        private readonly IProductService productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesService"/> class.
        /// </summary>
        /// <param name="salesRepository">The sales repository.</param>
        /// <param name="productService">The product repository.</param>
        public SalesService(ISalesRepository salesRepository, IProductService productService)
        {
            this.salesRepository = salesRepository;
            this.productService = productService;
        }

        /// <inheritdoc/>
        public async Task<SalesItemDetails> AddItemToSaleAsync(SaleItemModel saleItem, CancellationToken cancellationToken)
        {
            // ToDo: Cache products.
            var product = await this.productService.GetProductByIdAsync(saleItem.ProductId, cancellationToken);

            return await this.salesRepository.AddItemToSaleAsync(
                new SaleItem()
                {
                    ProductId = saleItem.ProductId,
                    Price = product.SalesPrice,
                    Vat = 00.00m,
                    Quantity = saleItem.Quantity,
                    Total = saleItem.Quantity * product.SalesPrice,
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public async Task AddItemToSaleAsync(SaleItemModel[] saleItems, CancellationToken cancellationToken)
        {
            foreach (var saleItem in saleItems)
            {
                var product = await this.productService.GetProductByIdAsync(saleItem.ProductId, cancellationToken);

                await this.salesRepository.AddItemToSaleAsync(
                    new SaleItem()
                    {
                        ProductId = saleItem.ProductId,
                        Price = product.SalesPrice,
                        Vat = 00.00m,
                        Quantity = saleItem.Quantity,
                        Total = saleItem.Quantity * product.SalesPrice,
                    },
                    cancellationToken);
            }
        }

        /// <inheritdoc/>
        public async Task<SalesDetails> CreateSaleAsync(SaleModel saleModel, CancellationToken cancellationToken)
        {
            var newSale = await this.salesRepository.CreateSaleAsync(
                new Sale()
                {
                    AccountId = saleModel.AccountId,
                    PaymentTypeId = saleModel.PaymentTypeId,
                    SalesStatusId = saleModel.SaleStatusId,
                    TotalItems = saleModel.Items.Length,
                    TimeStamp = DateTime.Now,
                },
                cancellationToken);

            List<SaleItem> saleItems = new List<SaleItem>();

            foreach (var saleItem in saleModel.Items)
            {
                var product = await this.productService.GetProductByIdAsync(saleItem.ProductId, cancellationToken);

                saleItems.Add(new SaleItem()
                {
                    SaleId = newSale.SaleId,
                    ProductId = product.ProductId,
                    Price = product.SalesPrice,
                    Vat = 00.00m,
                    Quantity = saleItem.Quantity,
                    Total = saleItem.Quantity * product.SalesPrice,
                });
            }

            await this.salesRepository.AddItemToSaleAsync(saleItems.ToArray(), cancellationToken);

            var result = await this.salesRepository.GetSaleByIdAsync(newSale.SaleId, cancellationToken);

            return result;
        }

        /// <inheritdoc/>
        public Task<SalesDetails> GetSaleItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return this.salesRepository.GetSaleByIdAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<SalesDetails[]> GetSalesAsync(CancellationToken cancellationToken)
        {
            return this.salesRepository.GetSalesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<SalesItemDetails[]> GetSalesItemBySaleIdAsync(int saleId, CancellationToken cancellationToken)
        {
            return this.salesRepository.GetSalesItemBySaleIdAsync(saleId, cancellationToken);
        }
    }
}
