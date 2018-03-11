using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Autofac;

namespace MOMO.Infrastructure
{
    public static class WebHostBuilderExtensions
    {
        /// <summary>
        /// Register MOMO.Infrastructure.InfrastructureFactory
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseInfrastructureFactory(this IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => services.AddSingleton<IServiceProviderFactory<ContainerBuilder>, InfrastructureFactory>());

			return builder;
        }
    }
}
