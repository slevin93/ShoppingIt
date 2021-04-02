// <copyright file="LookupService.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Services
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShoppingIt.Crm.Core.Dto.Lookup;
    using ShoppingIt.Crm.Core.Repository;

    /// <summary>
    /// Implements lookup service operations.
    /// </summary>
    public class LookupService : ILookupService
    {
        private readonly ILookupRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupService"/> class.
        /// </summary>
        /// <param name="repository">The loopup reposutory.</param>
        public LookupService(ILookupRepository repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public Task<SalesStatusDetails[]> GetSaleStatusAsync(CancellationToken cancellationToken)
        {
            return this.repository.GetSaleStatusAsync(cancellationToken);
        }
    }
}
