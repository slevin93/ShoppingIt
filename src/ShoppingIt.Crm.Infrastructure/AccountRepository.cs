using AutoMapper;
using ShoppingIt.Crm.Core.Dto.Accounts;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Domain;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Infrastructure
{
    public class AccountRepository : RepositoryBase, IAccountRepository
    {
        public AccountRepository(ShoppingItContext context, IMapper mapper)
            : base(context, mapper) { }

        public Task<AccountAuthDetails> GetAccountByEmailAsync(string email)
        {
            return FirstOrDefaultAsync<Account, AccountAuthDetails>(x => x.Email == email);
        }

        public Task<AccountDetails[]> GetAccountsAsync()
        {
            return GetArrayAsync<Account, AccountDetails>();
        }

        public Task<AccountDetails> RegisterAsync(Account account)
        {
            return AddAsync<Account, AccountDetails>(account);
        }
    }
}
