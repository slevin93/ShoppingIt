using AutoMapper;
using ShoppingIt.Crm.Core.Dto.Company;
using ShoppingIt.Crm.Core.Repository;
using ShoppingIt.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Infrastructure
{
    public class CompanyRepository : RepositoryBase, ICompanyRepository
    {
        public CompanyRepository(ShoppingItContext context, IMapper mapper)
            : base(context, mapper) { }

        public Task<CompanyDetails> GetCompanyByIdAsync(int id, CancellationToken cancellationToken)
        {
            return FirstOrDefaultAsync<Company, CompanyDetails>(x => x.CompanyId == id, cancellationToken);
        }

        public Task<CompanyDetails> RegisterCompanyAsync(Company company, CancellationToken cancellationToken)
        {
            return AddAsync<Company, CompanyDetails>(company, cancellationToken);
        }
    }
}
