using ShoppingIt.Crm.Core.Dto;
using ShoppingIt.Crm.Core.Dto.Lookup;
using ShoppingIt.Crm.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Services
{
    public class LookupService : ILookupService
    {
        private readonly ILookupRepository repository;

        public LookupService(ILookupRepository repository)
        {
            this.repository = repository;
        }

        public Task<SalesStatusDetails[]> GetSaleStatusAsync()
        {
            return repository.GetSaleStatusAsync();
        }
    }
}
