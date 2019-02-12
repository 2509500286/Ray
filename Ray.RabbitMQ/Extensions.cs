﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Ray.Core;
using Ray.Core.EventBus;

namespace Ray.EventBus.RabbitMQ
{
    public static class Extensions
    {
        public static void AddRabbitMQ(
            this IServiceCollection serviceCollection,
            Func<IRabbitEventBusContainer, Task> configure)
        {
            serviceCollection.AddSingleton<IRabbitMQClient, RabbitMQClient>();
            serviceCollection.AddSingleton<IConsumerManager, ConsumerManager>();
            serviceCollection.AddSingleton<IRabbitEventBusContainer, EventBusContainer>();
            serviceCollection.AddSingleton(serviceProvider => serviceProvider.GetService<IRabbitEventBusContainer>() as IProducerContainer);
            Startup.Register(serviceProvider =>
            {
                return configure(serviceProvider.GetService<IRabbitEventBusContainer>());
            });
        }
    }
}
