using AutoMapper;
using ShoppingIt.Crm.Core.Dto.Accounts;
using ShoppingIt.Crm.Domain;

namespace ShoppingIt.Crm.Infrastructure.Mapper
{
    /// <summary>
    /// Defines the mappings for accounts.
    /// </summary>
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            CreateMap<Account, AccountAuthDetails>().ReverseMap();

            CreateMap<Account, AccountDetails>().ReverseMap();
        }
    }
}
