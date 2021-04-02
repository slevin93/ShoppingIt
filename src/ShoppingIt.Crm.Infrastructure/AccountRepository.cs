// <copyright file="AccountRepository.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Infrastructure
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using ShoppingIt.Crm.Core.Dto.Accounts;
    using ShoppingIt.Crm.Core.Repository;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// The account data access layer.
    /// </summary>
    public class AccountRepository : RepositoryBase, IAccountRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="context">The ShoppingIt db context.</param>
        /// <param name="mapper">The mapper.</param>
        public AccountRepository(ShoppingItContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        /// <inheritdoc/>
        public Task<AccountAuthDetails> GetAccountByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return this.FirstOrDefaultAsync<Account, AccountAuthDetails>(x => x.Email == email, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<AccountDetails[]> GetAccountsAsync(CancellationToken cancellationToken)
        {
            return this.GetArrayAsync<Account, AccountDetails>(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<AccountDetails> RegisterAsync(Account account)
        {
            return this.AddAsync<Account, AccountDetails>(account);
        }
    }
}
