using ShoppingIt.Crm.Core.Repository.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Services.Cache
{
    public class CacheService : ICacheService
    {
        private ICacheRepository cache;

        public CacheService(ICacheRepository cache)
        {
            this.cache = cache;
        }
    }
}
