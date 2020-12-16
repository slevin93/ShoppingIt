using Microsoft.Extensions.DependencyInjection;
using ShoppingIt.Crm.Core.Services.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Api.Injection
{
    public static class InjectServices
    {
        public static IServiceCollection InjectShoppingItServices(this IServiceCollection services)
        {
            services.AddSingleton<IHashService, HashService>();

            return services;
        }
    }
}
