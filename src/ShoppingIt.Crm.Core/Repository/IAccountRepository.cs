using ShoppingIt.Crm.Core.Dto.Accounts;
using ShoppingIt.Crm.Domain;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Repository
{
    /// <summary>
    /// Defines the account data access.
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Returns account auth details from the database where email = <paramref name="email"/>.
        /// </summary>
        /// <param name="email">The email to search.</param>
        /// <returns>Returns account auth details where email addresses match query.</returns>
        Task<AccountAuthDetails> GetAccountByEmailAsync(string email);

        /// <summary>
        /// Registers new account.
        /// </summary>
        /// <param name="account">The account to save to database.</param>
        /// <returns>Returns newly created account.</returns>
        Task<AccountDetails> RegisterAsync(Account account);
    }
}
