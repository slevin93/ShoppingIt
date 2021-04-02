// <copyright file="AccountMapper.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Infrastructure.Mapper
{
    using AutoMapper;
    using ShoppingIt.Crm.Core.Dto.Accounts;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// Implement mapper profile for account.
    /// </summary>
    public class AccountMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountMapper"/> class.
        /// </summary>
        public AccountMapper()
        {
            this.CreateMap<Account, AccountAuthDetails>().ReverseMap();

            this.CreateMap<Account, AccountDetails>().ReverseMap();
        }
    }
}
