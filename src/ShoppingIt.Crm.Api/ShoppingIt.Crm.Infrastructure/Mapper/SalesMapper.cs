using AutoMapper;
using ShoppingIt.Crm.Core.Dto.Sales;
using ShoppingIt.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Infrastructure.Mapper
{
    public class SalesMapper : Profile
    {
        public SalesMapper()
        {
            CreateMap<Sale, SalesDetails>().ReverseMap();

            CreateMap<SaleItem, SalesItemDetails>().ReverseMap();
        }
    }
}
