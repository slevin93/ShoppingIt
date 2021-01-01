using ShoppingIt.Crm.Core.Models.Account;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Core.Services.Hash;
using ShoppingIt.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IHashService hashService;

        public AccountService(IAccountRepository accountRepository, IHashService hashService)
        {
            this.accountRepository = accountRepository;
            this.hashService = hashService;
        }

        public async Task<Account> RegisterAsync(AccountRequestModel accountReqModel)
        {
            var account = await this.accountRepository.GetAccountByEmailAsync(accountReqModel.Email);

            if (account != null)
            {
                return null;
            }

            string salt = this.hashService.GenerateSalt();

            string hashPassword = this.hashService.Hash(accountReqModel.Password, salt);

            return await accountRepository.RegisterAsync(new Account()
            {
                AccountId = new Guid().ToString(),
                Email = accountReqModel.Email,
                Password = hashPassword,
                Salt = salt,
                TimeStamp = DateTime.Now
            });
        }
    }
}
