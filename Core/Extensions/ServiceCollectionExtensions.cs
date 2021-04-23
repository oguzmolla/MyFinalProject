using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // Bu method ekleyebileceğimiz tüm modülleri serviceCollectiona ekleyecektir.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection,
            ICoreModel[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}
