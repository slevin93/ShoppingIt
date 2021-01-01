using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingIt.Crm.Core.Models;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Core.Services.Accounts;
using ShoppingIt.Crm.Core.Services.Hash;
using ShoppingIt.Crm.Infrastructure;
using ShoppingIt.Crm.Infrastructure.Mapper;

namespace ShoppingIt.Crm.Api.Injection
{
    public static class InjectServices
    {
        public static IServiceCollection InjectShoppingItServices(this IServiceCollection services)
        {
            services.AddSingleton<IHashService, HashService>();

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Validator>());

            services.AddAutoMapper(typeof(AccountMapper));

            return services;
        }
    }
}
