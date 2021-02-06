using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingIt.Crm.Core.Dto.Products;
using ShoppingIt.Crm.Core.Models.Product;
using ShoppingIt.Crm.Core.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
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
        public async Task<ActionResult<ProductDetails>> AddProduct(ProductModel productModel)
        {
            var product = await productService.AddProductAsync(productModel);

            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        /// <summary>
        /// Get a list of all products.
        /// </summary>
        /// <returns>Returns an array of products.</returns>
        [HttpGet]
        public async Task<ActionResult<ProductDetails[]>> GetProducts()
        {
            return Ok(await productService.GetProductsAsync());
        }

        /// <summary>
        /// Get product by product id.
        /// </summary>
        /// <param name="productId">The product id to return.</param>
        /// <returns>Return product where product id is equal to the provided product id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetails>> GetProductById(int id)
        {
            return Ok(await productService.GetProductByIdAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteProduct>> DeleteProductById(int id)
        {
            return Ok(await productService.DeleteProductByIdAsync(id));
        }
    }
}
