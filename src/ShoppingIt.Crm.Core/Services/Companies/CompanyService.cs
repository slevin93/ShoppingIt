using ShoppingIt.Crm.Core.Dto.Company;
using ShoppingIt.Crm.Core.Models.Company;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Core.Services.Accounts;
using ShoppingIt.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Services.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IAccountService accountService;

        public CompanyService(ICompanyRepository companyRepository, IAccountService accountService)
        {
            this.companyRepository = companyRepository;
            this.accountService = accountService;
        }

        public Task<CompanyDetails> GetCompanyByIdAsync(int id)
        {
            return companyRepository.GetCompanyByIdAsync(id);
        }

        public async Task<CompanyDetails> RegisterCompanyAsync(RegisterCompanyModel company)
        {
            var companyDetails = await companyRepository.RegisterCompanyAsync(new Company()
            {
                Name = company.Name,
                Description = company.Description,
                AddressLine1 = company.AddressLine1,
                AddressLine2 = company.AddressLine2,
                AddressLine3 = company.AddressLine3,
                AddressLine4 = company.AddressLine4
            });

            foreach (var account in company.Accounts)
            {
                account.CompanyId = companyDetails.CompanyId;

                await accountService.RegisterAsync(account);
            }

            return companyDetails;
        }
    }
}
