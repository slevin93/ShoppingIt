using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingIt.Crm.Core.Dto;
using ShoppingIt.Crm.Core.Dto.Accounts;
using ShoppingIt.Crm.Core.Models.Account;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Core.Services.Error;
using ShoppingIt.Crm.Core.Services.Hash;
using ShoppingIt.Crm.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IHashService hashService;
        private readonly IConfiguration configuration;
        private readonly IErrorService errorService;

        public AccountService(IAccountRepository accountRepository, 
            IHashService hashService,
            IConfiguration configuration,
            IErrorService errorService)
        {
            this.accountRepository = accountRepository;
            this.hashService = hashService;
            this.configuration = configuration;
            this.errorService = errorService;
        }

        public async Task<AccountDetails> RegisterAsync(RegisterModel accountModel)
        {
            var account = await this.accountRepository.GetAccountByEmailAsync(accountModel.Email);

            if (account != null)
            {
                errorService.HandleBadRequest("Invalid account details.");
            }

            string salt = this.hashService.GenerateSalt();

            string hashPassword = this.hashService.Hash(accountModel.Password, salt);

            return await accountRepository.RegisterAsync(new Account()
            {
                CompanyId = accountModel.CompanyId,
                Email = accountModel.Email,
                Password = hashPassword,
                Salt = salt,
                TimeStamp = DateTime.Now
            });
        }

        public async Task<AccessToken> LoginAsync(LoginModel loginModel)
        {
            var account = await accountRepository
                .GetAccountByEmailAsync(loginModel.Email);

            if (account is null)
            {
                throw new Exception("Invalid user credentials");
            }

            if (!hashService.IsValid(hashService.Hash(loginModel.Password, account.Salt), account.Password))
            {
                throw new Exception("Invalid user credentials");
            }

            // ToDo: Roles and claims

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new AccessToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiry = token.ValidTo
            };
        }
    }
}
