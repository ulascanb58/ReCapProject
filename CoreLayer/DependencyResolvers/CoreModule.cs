using CoreLayer.CrossCuttingConcerns.Caching;
using CoreLayer.CrossCuttingConcerns.Caching.Microsoft;
using CoreLayer.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); //cachenin çalışmasını sağlıyor
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheService, MemoryCacheManager>();
        }
    }
}
