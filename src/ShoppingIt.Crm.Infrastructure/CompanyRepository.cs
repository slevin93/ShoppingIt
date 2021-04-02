// <copyright file="CompanyRepository.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Infrastructure
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using ShoppingIt.Crm.Core.Dto.Company;
    using ShoppingIt.Crm.Core.Repository;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// The company data access layer.
    /// </summary>
    public class CompanyRepository : RepositoryBase, ICompanyRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyRepository"/> class.
        /// </summary>
        /// <param name="context">The ShoppingIt db context.</param>
        /// <param name="mapper">The mapper.</param>
        public CompanyRepository(ShoppingItContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        /// <inheritdoc/>
        public Task<CompanyDetails> GetCompanyByIdAsync(int id, CancellationToken cancellationToken)
        {
            return this.FirstOrDefaultAsync<Company, CompanyDetails>(x => x.CompanyId == id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<CompanyDetails> RegisterCompanyAsync(Company company, CancellationToken cancellationToken)
        {
            return this.AddAsync<Company, CompanyDetails>(company, cancellationToken);
        }
    }
}
