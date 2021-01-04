using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingIt.Crm.Core.Dto;
using ShoppingIt.Crm.Core.Dto.Accounts;
using ShoppingIt.Crm.Core.Models.Account;
using ShoppingIt.Crm.Core.Repository;
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

        public AccountService(IAccountRepository accountRepository, 
            IHashService hashService,
            IConfiguration configuration)
        {
            this.accountRepository = accountRepository;
            this.hashService = hashService;
            this.configuration = configuration;
        }

        public async Task<AccountDetails> RegisterAsync(RegisterModel accountModel)
        {
            var account = await this.accountRepository.GetAccountByEmailAsync(accountModel.Email);

            if (account != null)
            {
                return null;
            }

            string salt = this.hashService.GenerateSalt();

            string hashPassword = this.hashService.Hash(accountModel.Password, salt);

            return await accountRepository.RegisterAsync(new Account()
            {
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

            if (account != null && !hashService.IsValid(hashService.Hash(loginModel.Password, account.Salt), account.Password))
            {
                return null;
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
