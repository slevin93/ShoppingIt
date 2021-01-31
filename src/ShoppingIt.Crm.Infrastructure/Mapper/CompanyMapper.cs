using AutoMapper;
using ShoppingIt.Crm.Core.Dto.Company;
using ShoppingIt.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Infrastructure.Mapper
{
    public class CompanyMapper : Profile
    {
        public CompanyMapper()
        {
            CreateMap<Company, CompanyDetails>().ReverseMap();
        }
    }
}
