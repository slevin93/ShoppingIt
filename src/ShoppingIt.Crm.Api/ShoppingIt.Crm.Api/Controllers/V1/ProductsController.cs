// <copyright file="ProductsController.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Api.Controllers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingIt.Crm.Core.Dto.Products;
    using ShoppingIt.Crm.Core.Models.Product;
    using ShoppingIt.Crm.Core.Services.Products;

    /// <summary>
    /// Handles queries relating to products.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productService">The injected product service.</param>
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Add new product.
        /// </summary>
        /// <param name="productModel">The details for the new product to add.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Return newly created product.</returns>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProductDetails>> AddProduct(ProductModel productModel, CancellationToken cancellationToken)
        {
            var product = await this.productService.AddProductAsync(productModel, cancellationToken);

            return this.CreatedAtAction(nameof(this.GetProductById), new { id = product.ProductId }, product);
        }

        /// <summary>
        /// Get a list of all products.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns an array of products.</returns>
        [HttpGet]
        public async Task<ActionResult<ProductDetails[]>> GetProducts(CancellationToken cancellationToken)
        {
            return this.Ok(await this.productService.GetProductsAsync(cancellationToken));
        }

        /// <summary>
        /// Get product by product id.
        /// </summary>
        /// <param name="id">The product id to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Return product where product id is equal to the provided product id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetails>> GetProductById(int id, CancellationToken cancellationToken)
        {
            return this.Ok(await this.productService.GetProductByIdAsync(id, cancellationToken));
        }

        /// <summary>
        /// Delete product with the provided id.
        /// </summary>
        /// <param name="id">The product id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns delete product id.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteProduct>> DeleteProductById(int id, CancellationToken cancellationToken)
        {
            return this.Ok(await this.productService.DeleteProductByIdAsync(id, cancellationToken));
        }
    }
}
