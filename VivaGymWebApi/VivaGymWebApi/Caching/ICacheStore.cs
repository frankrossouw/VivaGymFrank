using System;

namespace VivaGymWebApi.Caching
{
  public interface ICacheStore
  {
    T GetCachedData<T>(string key);
    void StoreDataInCache<T>(string key, T data);
    void RemoveCachedData(String key);
  }
}