using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingIt.Crm.Core.Dto.Sales;
using ShoppingIt.Crm.Core.Models.Sales;
using ShoppingIt.Crm.Core.Services.Sales;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService salesService;

        public SalesController(ISalesService salesService)
        {
            this.salesService = salesService;
        }

        /// <summary>
        /// Add new sale record.
        /// </summary>
        /// <param name="saleModel">The sale details.</param>
        /// <returns>Returns newly created sale.</returns>
        [HttpPost]
        public async Task<ActionResult<SalesDetails>> AddSales(SaleModel saleModel, CancellationToken cancellationToken)
        {
            return Ok(await salesService.CreateSaleAsync(saleModel, cancellationToken));
        }

        /// <summary>
        /// Gets all sales on record.
        /// </summary>
        /// <returns>Returns list of sales.</returns>
        [HttpGet]
        public async Task<ActionResult<SalesDetails[]>> GetSales(CancellationToken cancellationToken)
        {
            return Ok(await salesService.GetSalesAsync(cancellationToken));
        }

        /// <summary>
        /// Get order details by order id.
        /// </summary>
        /// <param name="id">The order id to return.</param>
        /// <returns>Returns the order details for the specified order id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesDetails>> GetSaleBySaleId(int id, CancellationToken cancellationToken)
        {
            return Ok(await salesService.GetSaleItemByIdAsync(id, cancellationToken));
        }

        [HttpGet("{id}/items")]
        public async Task<ActionResult<SalesItemDetails>> GetSaleItems(int id, CancellationToken cancellationToken)
        {
            return Ok(await salesService.GetSalesItemBySaleIdAsync(id, cancellationToken));
        }
    }
}
