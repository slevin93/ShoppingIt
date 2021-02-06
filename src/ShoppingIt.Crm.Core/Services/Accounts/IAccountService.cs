﻿using ShoppingIt.Crm.Core.Dto;
using ShoppingIt.Crm.Core.Dto.Accounts;
using ShoppingIt.Crm.Core.Models.Account;
using ShoppingIt.Crm.Domain;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Services.Accounts
{
    /// <summary>
    /// Defines business logic for accounts.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Register new account.
        /// </summary>
        /// <param name="accountReqModel">Account details to register.</param>
        /// <returns>Newly created account details.</returns>
        Task<AccountDetails> RegisterAsync(RegisterModel accountModel);

        /// <summary>
        /// Login with user where credentials match provided login details.
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        Task<AccessToken> LoginAsync(LoginModel loginModel);

        /// <summary>
        /// Get list of accounts
        /// </summary>
        /// <returns>Returns list of accounts</returns>
        Task<AccountDetails[]> GetAccountsAsync();
    }
}
