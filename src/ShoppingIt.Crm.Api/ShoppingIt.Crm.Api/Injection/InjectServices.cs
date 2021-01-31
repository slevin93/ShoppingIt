using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingIt.Crm.Core.Models;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Core.Services.Accounts;
using ShoppingIt.Crm.Core.Services.Companies;
using ShoppingIt.Crm.Core.Services.Hash;
using ShoppingIt.Crm.Core.Services.Products;
using ShoppingIt.Crm.Core.Services.Sales;
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

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<ISalesService, SalesService>();
            services.AddTransient<ISalesRepository, SalesRepository>();

            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Validator>());

            services.AddAutoMapper(typeof(AccountMapper),
                typeof(ProductMapper),
                typeof(CompanyMapper));
                // typeof(SalesMapper));

            return services;
        }
    }
}
