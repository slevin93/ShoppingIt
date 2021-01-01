using AutoMapper;
using ShoppingIt.Crm.Core.Dto.Accounts;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Domain;
using System;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Infrastructure
{
    public class AccountRepository : RepositoryBase, IAccountRepository
    {
        public AccountRepository(ShoppingItContext context, IMapper mapper)
            : base(context, mapper) { }

        public Task<AccountAuthDto> GetAccountByEmailAsync(string email)
        {
            return FirstOrDefaultAsync<Account, AccountAuthDto>(x => x.Email == email);
        }

        public Task<AccountDetailsDto> RegisterAsync(Account account)
        {
            return AddAsync<Account, AccountDetailsDto>(account);
        }
    }
}
