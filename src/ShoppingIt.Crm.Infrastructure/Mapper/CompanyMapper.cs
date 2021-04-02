// <copyright file="CompanyMapper.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Infrastructure.Mapper
{
    using AutoMapper;
    using ShoppingIt.Crm.Core.Dto.Company;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// Implement mapper profile for company.
    /// </summary>
    public class CompanyMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyMapper"/> class.
        /// </summary>
        public CompanyMapper()
        {
            this.CreateMap<Company, CompanyDetails>().ReverseMap();
        }
    }
}
