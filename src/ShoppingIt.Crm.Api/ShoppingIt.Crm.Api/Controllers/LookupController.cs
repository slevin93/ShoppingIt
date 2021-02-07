using Microsoft.AspNetCore.Mvc;
using ShoppingIt.Crm.Core.Dto.Lookup;
using ShoppingIt.Crm.Core.Services;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Api.Controllers
{
    /// <summary>
    /// Get lookup items for dropdown lists.
    /// </summary>
    [Route("api/lookups")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILookupService lookupService;

        public LookupController(ILookupService lookupService)
        {
            this.lookupService = lookupService;
        }

        /// <summary>
        /// Get list of sales statuses.
        /// </summary>
        /// <returns>Returns a list of sales status.</returns>
        [HttpGet("sales-status")]
        public async Task<ActionResult<SalesStatusDetails>> GetSalesStatus()
        {
            return Ok(await this.lookupService.GetSaleStatusAsync());
        }
    }
}
