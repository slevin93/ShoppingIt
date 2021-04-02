// <copyright file="IAccountRepository.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Repository
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShoppingIt.Crm.Core.Dto.Accounts;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// Defines the account data access.
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Returns account auth details from the database where email = <paramref name="email"/>.
        /// </summary>
        /// <param name="email">The email to search.</param>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns account auth details where email addresses match query.</returns>
        Task<AccountAuthDetails> GetAccountByEmailAsync(string email, CancellationToken cancellationToken);

        /// <summary>
        /// Registers new account.
        /// </summary>
        /// <param name="account">The account to save to database.</param>
        /// <returns>Returns newly created account.</returns>
        Task<AccountDetails> RegisterAsync(Account account);

        /// <summary>
        /// Get list of accounts.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns list of accounts.</returns>
        Task<AccountDetails[]> GetAccountsAsync(CancellationToken cancellationToken);
    }
}
