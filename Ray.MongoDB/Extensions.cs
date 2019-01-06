﻿using Microsoft.Extensions.DependencyInjection;
using Ray.Core;
using Ray.Core.Abstractions;

namespace Ray.Storage.MongoDB
{
    public static class Extensions
    {
        public static void AddMongoDBStorage(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IStorageContainer, StorageContainer>();
            serviceCollection.AddSingleton(serviceProvider => serviceProvider.GetService<IStorageContainer>() as IConfigContainer);
            Startup.Register(serviceProvider =>
            {
                return serviceProvider.GetService<IStorageConfig>().Configure(serviceProvider.GetService<IConfigContainer>());
            });
        }
    }
}
