using Autofac;
using MOMO.Infrastructure.UnitOfWork;
using System;

namespace MOMO.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Register UnitOfWork provider
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static ContainerBuilder AddUnitOfWork(this ContainerBuilder builder, Action<IUnitOfWorkProvider> configAction = null)
        {
            builder.RegisterType<UnitOfWorkProvider>()
                .As<IUnitOfWorkProvider>()
                .OnActivating(e => 
                {
                    configAction?.Invoke(e.Instance);
                })    
                .SingleInstance();

            return builder;
        }
    }
}
