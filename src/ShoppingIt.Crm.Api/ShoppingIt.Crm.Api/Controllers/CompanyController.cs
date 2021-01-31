﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingIt.Crm.Core.Dto.Company;
using ShoppingIt.Crm.Core.Models.Company;
using ShoppingIt.Crm.Core.Services.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Api.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDetails>> RegisterCompany(RegisterCompanyModel companyModel)
        {
            var companyDetails = await companyService.RegisterCompanyAsync(companyModel);

            return CreatedAtAction(nameof(GetCompany), new { id = companyDetails.CompanyId }, companyDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDetails>> GetCompany(int id)
        {
            return Ok(await this.companyService.GetCompanyByIdAsync(id)); 
        }
    }
}
