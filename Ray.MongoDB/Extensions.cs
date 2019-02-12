﻿using Microsoft.Extensions.DependencyInjection;
using Ray.Core;
using Ray.Core.Storage;

namespace Ray.Storage.MongoDB
{
    public static class Extensions
    {
        public static void AddMongoDBStorage<MongoDBStorageConfig>(this IServiceCollection serviceCollection)
            where MongoDBStorageConfig : class, IStorageConfiguration<StorageConfig, ConfigParameter>
        {
            serviceCollection.AddSingleton<IMongoStorage, MongoStorage>();
            serviceCollection.AddSingleton<IBaseStorageFactory<StorageConfig>, StorageFactory>();
            serviceCollection.AddSingleton<IStorageConfiguration<StorageConfig, ConfigParameter>, MongoDBStorageConfig>();
            Startup.Register(serviceProvider =>
            {
                return serviceProvider.GetService<IStorageConfiguration<StorageConfig, ConfigParameter>>().
                   Configure(serviceProvider.GetService<IConfigureBuilderContainer>());
            });
        }
    }
}
