// <copyright file="LookupsController.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Api.Controllers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingIt.Crm.Core.Dto.Lookup;
    using ShoppingIt.Crm.Core.Services;

    /// <summary>
    /// Get lookup items for dropdown lists.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private readonly ILookupService lookupService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupsController"/> class.
        /// </summary>
        /// <param name="lookupService">The injected lookup service.</param>
        public LookupsController(ILookupService lookupService)
        {
            this.lookupService = lookupService;
        }

        /// <summary>
        /// Get list of sales statuses.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a list of sales status.</returns>
        [HttpGet("sales-status")]
        public async Task<ActionResult<SalesStatusDetails>> GetSalesStatus(CancellationToken cancellationToken)
        {
            return this.Ok(await this.lookupService.GetSaleStatusAsync(cancellationToken));
        }

        /// <summary>
        /// Gets list of payment types.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a list of cancellation tokens.</returns>
        [HttpGet("payment-types")]
        public async Task<ActionResult<PaymentTypeDetails>> GetPaymentType(CancellationToken cancellationToken)
        {
            return this.Ok(await this.lookupService.GetPaymentTypeAsync(cancellationToken));
        }

        /// <summary>
        /// Gets payment type details where payment type id is equal to the provided id.
        /// </summary>
        /// <param name="id">The payment type id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns payment type details where payment type is equal to provided id.</returns>
        [HttpGet("payment-types/{id}")]
        public async Task<ActionResult<PaymentTypeDetails>> GetPaymentTypeById(int id, CancellationToken cancellationToken)
        {
            return this.Ok(await this.lookupService.GetPaymentTypeByIdAsync(id, cancellationToken));
        }

        /// <summary>
        /// Gets order status.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns list of order status.</returns>
        [HttpGet("order-status")]
        public async Task<ActionResult<OrderStatusDetails>> GetOrderStatus(CancellationToken cancellationToken)
        {
            return this.Ok(await this.lookupService.GetSaleStatusAsync(cancellationToken));
        }
    }
}
