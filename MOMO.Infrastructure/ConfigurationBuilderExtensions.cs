﻿using Microsoft.Extensions.Configuration;
using MOMO.Infrastructure.Configuration.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOMO.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConfigurationBuilderExtensions
    {
        /// <summary>
        /// Add database source
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="options"></param>
        public static IConfigurationBuilder AddDatabase(this IConfigurationBuilder builder, DatabaseConfigurationOptions options)
        {
            return builder.Add(new DatabaseConfigurationSource(options));
        }
    }
}
