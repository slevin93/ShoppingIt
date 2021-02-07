using ShoppingIt.Crm.Core.Dto;
using ShoppingIt.Crm.Core.Dto.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Repository
{
    public interface ILookupRepository
    {
        /// <summary>
        /// Gets list of sales status.
        /// </summary>
        /// <returns>Returns array of sales status.</returns>
        Task<SalesStatusDetails[]> GetSaleStatusAsync();
    }
}
