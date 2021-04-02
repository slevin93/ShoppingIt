// <copyright file="AccountService.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Services.Accounts
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using ShoppingIt.Crm.Core.Dto;
    using ShoppingIt.Crm.Core.Dto.Accounts;
    using ShoppingIt.Crm.Core.Models.Account;
    using ShoppingIt.Crm.Core.Repository;
    using ShoppingIt.Crm.Core.Services.Error;
    using ShoppingIt.Crm.Core.Services.Hash;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// Implement account service operations.
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IHashService hashService;
        private readonly IConfiguration configuration;
        private readonly IErrorService errorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="accountRepository">The account repository.</param>
        /// <param name="hashService">The hash service.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="errorService">The error service.</param>
        public AccountService(
            IAccountRepository accountRepository,
            IHashService hashService,
            IConfiguration configuration,
            IErrorService errorService)
        {
            this.accountRepository = accountRepository;
            this.hashService = hashService;
            this.configuration = configuration;
            this.errorService = errorService;
        }

        /// <inheritdoc/>
        public async Task<AccountDetails> RegisterAsync(RegisterModel accountModel, CancellationToken cancellationToken)
        {
            var account = await this.accountRepository.GetAccountByEmailAsync(accountModel.Email, cancellationToken);

            if (account != null)
            {
                this.errorService.HandleBadRequest("Invalid account details.");
            }

            string salt = this.hashService.GenerateSalt();

            string hashPassword = this.hashService.Hash(accountModel.Password, salt);

            return await this.accountRepository.RegisterAsync(new Account()
            {
                CompanyId = accountModel.CompanyId,
                Email = accountModel.Email,
                Password = hashPassword,
                Salt = salt,
                TimeStamp = DateTime.Now,
            });
        }

        /// <inheritdoc/>
        public async Task<AccessToken> LoginAsync(LoginModel loginModel, CancellationToken cancellationToken)
        {
            var account = await this.accountRepository
                .GetAccountByEmailAsync(loginModel.Email, cancellationToken);

            if (account is null)
            {
                throw new Exception("Invalid user credentials");
            }

            if (!this.hashService.IsValid(this.hashService.Hash(loginModel.Password, account.Salt), account.Password))
            {
                throw new Exception("Invalid user credentials");
            }

            // ToDo: Roles and claims
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: this.configuration["JWT:ValidIssuer"],
                audience: this.configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return new AccessToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiry = token.ValidTo,
            };
        }

        /// <inheritdoc/>
        public Task<AccountDetails[]> GetAccountsAsync(CancellationToken cancellationToken)
        {
            return this.accountRepository.GetAccountsAsync(cancellationToken);
        }
    }
}
