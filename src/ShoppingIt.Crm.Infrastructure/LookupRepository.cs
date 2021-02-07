using AutoMapper;
using ShoppingIt.Crm.Core.Dto;
using ShoppingIt.Crm.Core.Dto.Lookup;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Infrastructure
{
    public class LookupRepository : RepositoryBase, ILookupRepository
    {
        public LookupRepository(ShoppingItContext context, IMapper mapper)
            : base(context, mapper) { }

        public Task<SalesStatusDetails[]> GetSaleStatusAsync()
        {
            return GetArrayAsync<SalesStatus, SalesStatusDetails>();
        }
    }
}
