using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Builder;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace MOMO.Infrastructure.Autofac
{
    /// <summary>
    /// Autofac IOC 容器
    /// </summary>
    public static class IoCContainer
    {
        private static ContainerBuilder _builder = new ContainerBuilder();
        private static IContainer _container;

        /// <summary>
        /// 构建IOC容器，需在各种Register后调用。
        /// </summary>
        public static IServiceProvider UseAutofac(this IServiceCollection services,List<string> assemblys, Func<ContainerBuilder,bool> option)
        {

            bool ssf = option.Invoke(_builder);
            List<Type> types = new List<Type>();
            foreach (var assemblyStr in assemblys)
            {
                var assembly = Assembly.Load(assemblyStr);
                types.AddRange(assembly.DefinedTypes);
            }
            List<Type> toDis = types.Where(s => s.GetCustomAttribute<DependencyRegisterAttribute>() != null).ToList();
            foreach (var type in toDis)
            {
                DependencyRegisterAttribute attribute = type.GetCustomAttribute<DependencyRegisterAttribute>();
                if (attribute.IsAsSelf)
                    _builder.RegisterType(type).AsSelf().InstancePerDependency();
                else
                {
                    Type interfaceType = types.First(s => s.GetTypeInfo() == attribute.InterfaceType);
                    switch (attribute.DependencyType)
                    {
                        case LifetimeScope.InstancePerDependency:
                            if (string.IsNullOrEmpty(attribute.Alias))
                                _builder.RegisterType(type).As(interfaceType).InstancePerDependency();
                            else
                                _builder.RegisterType(type).Named(attribute.Alias, interfaceType).InstancePerDependency();

                            break;
                        case LifetimeScope.InstancePerLifetimeScope:
                            if (string.IsNullOrEmpty(attribute.Alias))
                                _builder.RegisterType(type).As(interfaceType).InstancePerLifetimeScope();
                            else
                                _builder.RegisterType(type).Named(attribute.Alias, interfaceType).InstancePerLifetimeScope();
                            break;
                        case LifetimeScope.InstancePerMatchingLifetimeScope:
                            if (string.IsNullOrEmpty(attribute.Alias))
                                _builder.RegisterType(type).As(interfaceType).InstancePerMatchingLifetimeScope();
                            else
                                _builder.RegisterType(type).Named(attribute.Alias, interfaceType).InstancePerMatchingLifetimeScope();
                            break;
                        case LifetimeScope.SingleInstance:
                            if (string.IsNullOrEmpty(attribute.Alias))
                                _builder.RegisterType(type).As(interfaceType).SingleInstance();
                            else
                                _builder.RegisterType(type).Named(attribute.Alias, interfaceType).SingleInstance();
                            break;
                        case LifetimeScope.InstancePerHttpRequest:
                            if (string.IsNullOrEmpty(attribute.Alias))
                                _builder.RegisterType(type).As(interfaceType).InstancePerRequest();
                            else
                                _builder.RegisterType(type).Named(attribute.Alias, interfaceType).InstancePerRequest();
                            break;
                    }
                }
            }

            _builder.Populate(services);
            _container = _builder.Build();
            return new AutofacServiceProvider(_container);
        }
        /// <summary>
        /// Resolve an instance of the default requested type from the container
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return _container.Resolve<T>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            return _container.ResolveNamed<T>(key);
        }

    }
}
