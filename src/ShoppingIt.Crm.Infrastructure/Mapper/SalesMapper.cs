// <copyright file="SalesMapper.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Infrastructure.Mapper
{
    using AutoMapper;
    using ShoppingIt.Crm.Core.Dto.Sales;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// Implement mapper profile for sales.
    /// </summary>
    public class SalesMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesMapper"/> class.
        /// </summary>
        public SalesMapper()
        {
            this.CreateMap<Sale, SalesDetails>().ReverseMap();

            this.CreateMap<SaleItem, SalesItemDetails>().ReverseMap();
        }
    }
}
