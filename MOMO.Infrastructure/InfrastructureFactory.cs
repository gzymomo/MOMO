using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MOMO.Infrastructure
{
	public class InfrastructureFactory : IServiceProviderFactory<ContainerBuilder>
    {
        public ContainerBuilder CreateBuilder(IServiceCollection services)
        {
            services.AddLogging();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);         

            return containerBuilder;
        }

        public IServiceProvider CreateServiceProvider(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<Background.BackgroundService>()
                .As<Background.IBackgroundService>()
                .SingleInstance();

            return new AutofacServiceProvider(containerBuilder.Build());
        }
    }
}
