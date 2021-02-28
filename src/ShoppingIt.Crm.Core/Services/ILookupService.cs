using ShoppingIt.Crm.Core.Dto;
using ShoppingIt.Crm.Core.Dto.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Services
{
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
