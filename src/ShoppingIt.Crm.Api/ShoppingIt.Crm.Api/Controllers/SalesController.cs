using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingIt.Crm.Core.Dto.Sales;
using ShoppingIt.Crm.Core.Models.Sales;
using ShoppingIt.Crm.Core.Services.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Api.Controllers
{
    [Authorize]
    [Route("api/sales")]
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
        public async Task<ActionResult<SalesDetails>> AddSales(SaleModel saleModel)
        {
            return Ok(await salesService.CreateSaleAsync(saleModel));
        }

        /// <summary>
        /// Gets all sales on record.
        /// </summary>
        /// <returns>Returns list of sales.</returns>
        [HttpGet]
        public async Task<ActionResult<SalesDetails[]>> GetSales()
        {
            return Ok(await salesService.GetSalesAsync());
        }
    }
}
