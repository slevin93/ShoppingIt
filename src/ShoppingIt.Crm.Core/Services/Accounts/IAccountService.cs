using ShoppingIt.Crm.Core.Dto;
using ShoppingIt.Crm.Core.Dto.Accounts;
using ShoppingIt.Crm.Core.Models.Account;
using ShoppingIt.Crm.Domain;
using System.Threading;
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
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Newly created account details.</returns>
        Task<AccountDetails> RegisterAsync(RegisterModel accountModel, CancellationToken cancellationToken);

        /// <summary>
        /// Login with user where credentials match provided login details.
        /// </summary>
        /// <param name="loginModel">The login details.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns></returns>
        Task<AccessToken> LoginAsync(LoginModel loginModel, CancellationToken cancellationToken);

        /// <summary>
        /// Get list of accounts
        /// 
        /// </summary>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns list of accounts.</returns>
        Task<AccountDetails[]> GetAccountsAsync(CancellationToken cancellationToken);
    }
}
