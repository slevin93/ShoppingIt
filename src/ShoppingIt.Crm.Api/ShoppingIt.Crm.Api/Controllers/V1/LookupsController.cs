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
    }
}
