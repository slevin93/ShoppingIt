// <copyright file="CompanyService.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Services.Companies
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShoppingIt.Crm.Core.Dto.Company;
    using ShoppingIt.Crm.Core.Models.Company;
    using ShoppingIt.Crm.Core.Repository;
    using ShoppingIt.Crm.Core.Services.Accounts;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// Implement company service operations.
    /// </summary>
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IAccountService accountService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyService"/> class.
        /// </summary>
        /// <param name="companyRepository">The company repository.</param>
        /// <param name="accountService">The account service.</param>
        public CompanyService(ICompanyRepository companyRepository, IAccountService accountService)
        {
            this.companyRepository = companyRepository;
            this.accountService = accountService;
        }

        /// <inheritdoc/>
        public Task<CompanyDetails> GetCompanyByIdAsync(int id, CancellationToken cancellationToken)
        {
            return this.companyRepository.GetCompanyByIdAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<CompanyDetails> RegisterCompanyAsync(RegisterCompanyModel company, CancellationToken cancellationToken)
        {
            var companyDetails = await this.companyRepository.RegisterCompanyAsync(
                new Company()
                {
                    Name = company.Name,
                    Description = company.Description,
                    AddressLine1 = company.AddressLine1,
                    AddressLine2 = company.AddressLine2,
                    AddressLine3 = company.AddressLine3,
                    AddressLine4 = company.AddressLine4,
                },
                cancellationToken);

            foreach (var account in company.Accounts)
            {
                account.CompanyId = companyDetails.CompanyId;

                await this.accountService.RegisterAsync(account, cancellationToken);
            }

            return companyDetails;
        }
    }
}