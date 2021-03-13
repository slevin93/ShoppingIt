using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingIt.Crm.Core.Dto.Products;
using ShoppingIt.Crm.Core.Models.Product;
using ShoppingIt.Crm.Core.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Add new product.
        /// </summary>
        /// <param name="productModel">The details for the new product to add.</param>
        /// <returns>Return newly created product.</returns>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProductDetails>> AddProduct(ProductModel productModel, CancellationToken cancellationToken)
        {
            var product = await productService.AddProductAsync(productModel, cancellationToken);

            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        /// <summary>
        /// Get a list of all products.
        /// </summary>
        /// <returns>Returns an array of products.</returns>
        [HttpGet]
        public async Task<ActionResult<ProductDetails[]>> GetProducts(CancellationToken cancellationToken)
        {
            return Ok(await productService.GetProductsAsync(cancellationToken));
        }

        /// <summary>
        /// Get product by product id.
        /// </summary>
        /// <param name="productId">The product id to return.</param>
        /// <returns>Return product where product id is equal to the provided product id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetails>> GetProductById(int id, CancellationToken cancellationToken)
        {
            return Ok(await productService.GetProductByIdAsync(id, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteProduct>> DeleteProductById(int id, CancellationToken cancellationToken)
        {
            return Ok(await productService.DeleteProductByIdAsync(id, cancellationToken));
        }
    }
}
