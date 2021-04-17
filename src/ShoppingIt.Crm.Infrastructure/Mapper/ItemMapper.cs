// <copyright file="ItemMapper.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Infrastructure.Mapper
{
    using AutoMapper;
    using ShoppingIt.Crm.Core.Dto.Lookup;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// Implement mapper profile for item.
    /// </summary>
    public class ItemMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemMapper"/> class.
        /// </summary>
        public ItemMapper()
        {
            this.CreateMap<SalesStatus, SalesStatusDetails>().ReverseMap();

            this.CreateMap<PaymentType, PaymentTypeDetails>().ReverseMap();

            this.CreateMap<SalesStatus, OrderStatusDetails>().ReverseMap();
        }
    }
}
