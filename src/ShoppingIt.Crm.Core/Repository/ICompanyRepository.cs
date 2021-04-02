// <copyright file="ICompanyRepository.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Repository
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShoppingIt.Crm.Core.Dto.Company;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// Interface defines company data access.
    /// </summary>
    public interface ICompanyRepository
    {
        /// <summary>
        /// Register a new company.
        /// </summary>
        /// <param name="company">The company details.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns newly created company details.</returns>
        Task<CompanyDetails> RegisterCompanyAsync(Company company, CancellationToken cancellationToken);

        /// <summary>
        /// Gets company details by company id.
        /// </summary>
        /// <param name="id">The company id.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns newly created company details.</returns>
        Task<CompanyDetails> GetCompanyByIdAsync(int id, CancellationToken cancellationToken);
    }
}
