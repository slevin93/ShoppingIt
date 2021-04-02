// <copyright file="InjectServices.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Api.Injection
{
    using System.Text;
    using AutoMapper;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Versioning;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using ShoppingIt.Crm.Core.Models;
    using ShoppingIt.Crm.Core.Repository;
    using ShoppingIt.Crm.Core.Services;
    using ShoppingIt.Crm.Core.Services.Accounts;
    using ShoppingIt.Crm.Core.Services.Companies;
    using ShoppingIt.Crm.Core.Services.Error;
    using ShoppingIt.Crm.Core.Services.Hash;
    using ShoppingIt.Crm.Core.Services.Products;
    using ShoppingIt.Crm.Core.Services.Sales;
    using ShoppingIt.Crm.Infrastructure;
    using ShoppingIt.Crm.Infrastructure.Mapper;

    /// <summary>
    /// This class will handle all the injected services for ShoppingIt.
    /// </summary>
    public static class InjectServices
    {
        /// <summary>
        /// Adds ShoppingIt services to service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>Returns the service collection with the ShoppingIt services.</returns>
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

            services.AddTransient<ILookupService, LookupService>();
            services.AddTransient<ILookupRepository, LookupRepository>();

            services.AddTransient<IErrorService, ErrorService>();

            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Validator>());

            services.AddAutoMapper(
                typeof(AccountMapper),
                typeof(ProductMapper),
                typeof(CompanyMapper),
                typeof(ItemMapper));

            return services;
        }

        /// <summary>
        /// Adds ShoppingIt authentication middleware.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Returns the service collection with ShoppingIt api versioning.</returns>
        public static IServiceCollection InjectShoppingItAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                };
            });

            return services;
        }

        /// <summary>
        /// Adds ShoppingIt api versioning middleware.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>Returns the service collection with ShoppingIt api versioning.</returns>
        public static IServiceCollection AddShoppingItApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = ApiVersionReader.Combine(new HeaderApiVersionReader("X-version"), new QueryStringApiVersionReader("api-version"));
            });

            return services;
        }

        /// <summary>
        /// Adds ShoppingIt db context.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Returns service collection with ShoppingIt db context.</returns>
        public static IServiceCollection AddShoppingItDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShoppingItContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        /// <summary>
        /// Adds ShoppingItCors.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="corsPolicy">The cors policy.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Returns service collection with cors added.</returns>
        public static IServiceCollection AddShoppingItCors(this IServiceCollection services, string corsPolicy, IConfiguration configuration)
        {
            var x = configuration.GetValue<string>("Cors");

            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: corsPolicy,
                    builder =>
                    {
                        builder.WithOrigins(configuration.GetValue<string>("Cors")).AllowAnyHeader().AllowAnyMethod();
                    });
            });

            return services;
        }
    }
}
