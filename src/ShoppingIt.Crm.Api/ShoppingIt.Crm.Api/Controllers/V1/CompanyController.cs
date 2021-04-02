// <copyright file="CompanyController.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Api.Controllers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingIt.Crm.Core.Dto.Company;
    using ShoppingIt.Crm.Core.Models.Company;
    using ShoppingIt.Crm.Core.Services.Companies;

    /// <summary>
    /// Handles queries relating to company.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyController"/> class.
        /// </summary>
        /// <param name="companyService">The injected company service.</param>
        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        /// <summary>
        /// Create new company.
        /// </summary>
        /// <param name="companyModel">The company details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns newly created company details.</returns>
        [HttpPost]
        public async Task<ActionResult<CompanyDetails>> RegisterCompany(RegisterCompanyModel companyModel, CancellationToken cancellationToken)
        {
            var companyDetails = await this.companyService.RegisterCompanyAsync(companyModel, cancellationToken);

            return this.CreatedAtAction(nameof(this.GetCompany), new { id = companyDetails.CompanyId }, companyDetails);
        }

        /// <summary>
        /// Get company by company id.
        /// </summary>
        /// <param name="id">The company id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns company details where company id equals provided company id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDetails>> GetCompany(int id, CancellationToken cancellationToken)
        {
            return this.Ok(await this.companyService.GetCompanyByIdAsync(id, cancellationToken));
        }
    }
}
