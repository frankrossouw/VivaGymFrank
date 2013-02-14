using System;
using System.Web;
using System.Web.Caching;
using VivaGymWebApi.Caching;

namespace VivaWeb.Infrastructure.Caching
{
  public class HTTPRuntimeCacheStore : ICacheStore
  {
    public T GetCachedData<T>(string key)
    {
      return (T)HttpRuntime.Cache[key];
    }

    public void StoreDataInCache<T>(string key, T data)
    {
      HttpRuntime.Cache.Add(key, data, null, DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, null);
    }

    public void RemoveCachedData(string key)
    {
      var data = HttpRuntime.Cache[key];
      if (data!=null)
      {
        HttpRuntime.Cache.Remove(key);
      }
    }
  }
}
