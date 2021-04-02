// <copyright file="ILookupService.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Services
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShoppingIt.Crm.Core.Dto.Lookup;

    /// <summary>
    /// Defines the lookup service operations.
    /// </summary>
    public interface ILookupService
    {
        /// <summary>
        /// Gets list of sales status.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns array of sales status.</returns>
        Task<SalesStatusDetails[]> GetSaleStatusAsync(CancellationToken cancellationToken);
    }
}
