// <copyright file="SalesController.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Api.Controllers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingIt.Crm.Core.Dto.Sales;
    using ShoppingIt.Crm.Core.Models.Sales;
    using ShoppingIt.Crm.Core.Services.Sales;

    /// <summary>
    /// Handles queries relating to sales.
    /// </summary>
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService salesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesController"/> class.
        /// </summary>
        /// <param name="salesService">Injected sales service.</param>
        public SalesController(ISalesService salesService)
        {
            this.salesService = salesService;
        }

        /// <summary>
        /// Add new sale record.
        /// </summary>
        /// <param name="saleModel">The sale details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns newly created sale.</returns>
        [HttpPost]
        public async Task<ActionResult<SalesDetails>> AddSales(SaleModel saleModel, CancellationToken cancellationToken)
        {
            return this.Ok(await this.salesService.CreateSaleAsync(saleModel, cancellationToken));
        }

        /// <summary>
        /// Gets all sales on record.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns list of sales.</returns>
        [HttpGet]
        public async Task<ActionResult<SalesDetails[]>> GetSales(CancellationToken cancellationToken)
        {
            return this.Ok(await this.salesService.GetSalesAsync(cancellationToken));
        }

        /// <summary>
        /// Get order details by order id.
        /// </summary>
        /// <param name="id">The order id to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns the order details for the specified order id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesDetails>> GetSaleBySaleId(int id, CancellationToken cancellationToken)
        {
            return this.Ok(await this.salesService.GetSaleItemByIdAsync(id, cancellationToken));
        }

        /// <summary>
        /// Get sales items relating to order id.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns sales items belonging to order id.</returns>
        [HttpGet("{id}/items")]
        public async Task<ActionResult<SalesItemDetails>> GetSaleItems(int id, CancellationToken cancellationToken)
        {
            return this.Ok(await this.salesService.GetSalesItemBySaleIdAsync(id, cancellationToken));
        }
    }
}
