// <copyright file="ILookupRepository.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Repository
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShoppingIt.Crm.Core.Dto.Lookup;

    /// <summary>
    /// Define lookup data access.
    /// </summary>
    public interface ILookupRepository
    {
        /// <summary>
        /// Gets list of sales status.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns array of sales status.</returns>
        Task<SalesStatusDetails[]> GetSaleStatusAsync(CancellationToken cancellationToken);
    }
}
