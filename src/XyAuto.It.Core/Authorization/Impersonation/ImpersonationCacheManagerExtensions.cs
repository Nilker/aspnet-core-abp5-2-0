using Abp.Runtime.Caching;

namespace XyAuto.It.Authorization.Impersonation
{
    public static class ImpersonationCacheManagerExtensions
    {
        public static ITypedCache<string, ImpersonationCacheItem> GetImpersonationCache(this ICacheManager cacheManager)
        {
            return cacheManager.GetCache<string, ImpersonationCacheItem>(ImpersonationCacheItem.CacheName);
        }
    }
}
