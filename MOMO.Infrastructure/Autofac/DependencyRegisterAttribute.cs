using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MOMO.Infrastructure.Autofac
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false,Inherited = false)]
    public class DependencyRegisterAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="interfaceFullName">完全限定名</param>
        /// <param name="alias">别名</param>
        /// <param name="type">生命周期</param>
        public DependencyRegisterAttribute(Type interfaceType, string alias="", LifetimeScope type = LifetimeScope.InstancePerDependency)
        {
            InterfaceType = interfaceType;
            Alias = alias;
            DependencyType = type;
        }
        public DependencyRegisterAttribute()
        {
            IsAsSelf = true;
            DependencyType = LifetimeScope.InstancePerDependency;
        }
        /// <summary>
        /// 完全限定名
        /// </summary>
        public Type InterfaceType { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 生命周期
        /// </summary>
        public LifetimeScope DependencyType { get; set; }

        /// <summary>
        /// 是否自身注入
        /// </summary>
        [DefaultValue(false)]
        public bool IsAsSelf { get; set; }
    }

    public enum LifetimeScope
    {
        /// <summary>
        /// 对每一个依赖或每一次调用创建一个新的唯一的实例。这也是默认的创建实例的方式。
        /// </summary>
        InstancePerDependency = 1,
        /// <summary>
        /// 在一个生命周期域中，每一个依赖或调用创建一个单一的共享的实例，
        /// 且每一个不同的生命周期域，实例是唯一的，不共享的。
        /// </summary>
        InstancePerLifetimeScope = 2,
        /// <summary>
        /// 每一次依赖组件或调用Resolve()方法都会得到一个相同的共享的实例。
        /// 其实就是单例模式
        /// </summary>
        SingleInstance = 3,
        /// <summary>
        /// 在一次Http请求上下文中,共享一个组件实例。仅适用于asp.net mvc开发
        /// </summary>
        InstancePerHttpRequest = 4,
        /// <summary>
        /// 在一个做标识的生命周期域中，每一个依赖或调用创建一个单一的共享的实例。
        /// 打了标识了的生命周期域中的子标识域中可以共享父级域中的实例。
        /// 若在整个继承层次中没有找到打标识的生命周期域，则会抛出异常：DependencyResolutionException。
        /// </summary>
        InstancePerMatchingLifetimeScope = 5,
        /// <summary>
        /// 在一个生命周期域中所拥有的实例创建的生命周期中，每一个依赖组件或调用Resolve()方法创建一个单一的共享的实例，
        /// 并且子生命周期域共享父生命周期域中的实例。
        /// 若在继承层级中没有发现合适的拥有子实例的生命周期域，
        /// 则抛出异常：DependencyResolutionException。
        /// </summary>
        InstancePerOwned = 6,
        
    }
}
