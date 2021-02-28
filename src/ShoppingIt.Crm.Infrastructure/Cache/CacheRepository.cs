using Microsoft.Extensions.Caching.Memory;
using ShoppingIt.Crm.Core.Repository.Cache;
using System;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Infrastructure.Cache
{
    public class CacheRepository : ICacheRepository
    {
        private IMemoryCache cache;

        public CacheRepository(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public T GetCache<T>(string key)
        {
            if (cache.TryGetValue(key, out object cacheEntry))
            {
                return (T)Convert.ChangeType(cacheEntry, typeof(T));
            }

            return default;
        }

        public T SetCacheItem<T>(string key, object data)
        {
            if (!cache.TryGetValue(key, out object cacheEntry))
            {
                cacheEntry = data;

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromDays(30));

                cache.Set(key, cacheEntry, cacheEntryOptions);
            }

            return (T)Convert.ChangeType(cacheEntry, typeof(T));
        }
    }
}
