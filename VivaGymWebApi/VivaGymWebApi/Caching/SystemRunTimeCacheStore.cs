using System;
using System.Collections.Specialized;
using System.Runtime.Caching;

namespace VivaGymWebApi.Caching
{
  public class SystemRunTimeCacheStore : ICacheStore
  {
    private readonly MemoryCache _cache;

    //constructor allows you to create multiple stores
    //note do not use "default" as the key since that is a reserved key by MemoryCache
    public SystemRunTimeCacheStore(string cacheKey)
    {
      var config = new NameValueCollection(); 
      _cache = new MemoryCache(cacheKey, config); 
    }

    public T GetCachedData<T>(string key)
    {
      return (T) _cache[key];
    }

    //you can store single objects 

    // i.e. cache.StoreDataInCache<Gender>("male", new Gender("Male"));

    //or collections

    // var genders = new List<Gender>(){new Gender("Male"), new Gender("Female")};
    // cache.StoreDataInCache<List<Gender>>("genders", genders);
    public void StoreDataInCache<T>(string key, T data)
    {
      var policy = new CacheItemPolicy
        {Priority = CacheItemPriority.NotRemovable };
      _cache.Set(key, data, policy);
    }

    public void RemoveCachedData(String key)
    {
      if (_cache.Contains(key))
      {
        _cache.Remove(key);
      }
    }
  }
}

