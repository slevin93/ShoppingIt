using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Repository.Cache
{
    public interface ICacheRepository
    {
        T GetCache<T>(string key);

        T SetCacheItem<T>(string key, object data);
    }
}
