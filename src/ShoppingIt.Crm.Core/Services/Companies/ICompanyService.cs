using ShoppingIt.Crm.Core.Dto.Company;
using ShoppingIt.Crm.Core.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Services.Companies
{
    public interface ICompanyService
    {
        /// <summary>
        /// Register a new company.
        /// </summary>
        /// <param name="company">The company details.</param>
        /// <returns>Returns newly created company details.</returns>
        Task<CompanyDetails> RegisterCompanyAsync(RegisterCompanyModel company);

        /// <summary>
        /// Gets company details by company id.
        /// </summary>
        /// <param name="id">The company id.</param>
        /// <returns>Returns newly created company details.</returns>
        Task<CompanyDetails> GetCompanyByIdAsync(int id);
    }
}
