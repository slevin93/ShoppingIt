// <copyright file="ProductMapper.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Infrastructure.Mapper
{
    using AutoMapper;
    using ShoppingIt.Crm.Core.Dto.Products;
    using ShoppingIt.Crm.Core.Models.Product;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// Implement mapper profile for product..
    /// </summary>
    public class ProductMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductMapper"/> class.
        /// </summary>
        public ProductMapper()
        {
            this.CreateMap<Product, ProductDetails>()
                  .ReverseMap();

            this.CreateMap<ProductModel, Product>();
        }
    }
}