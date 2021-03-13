using Microsoft.AspNetCore.Mvc;
using ShoppingIt.Crm.Core.Dto.Lookup;
using ShoppingIt.Crm.Core.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Api.Controllers
{
    /// <summary>
    /// Get lookup items for dropdown lists.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private readonly ILookupService lookupService;

        public LookupsController(ILookupService lookupService)
        {
            this.lookupService = lookupService;
        }

        /// <summary>
        /// Get list of sales statuses.
        /// </summary>
        /// <returns>Returns a list of sales status.</returns>
        [HttpGet("sales-status")]
        public async Task<ActionResult<SalesStatusDetails>> GetSalesStatus(CancellationToken cancellationToken)
        {
            return Ok(await this.lookupService.GetSaleStatusAsync(cancellationToken));
        }
    }
}
