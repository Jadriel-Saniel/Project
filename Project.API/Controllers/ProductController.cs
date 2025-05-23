﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project.Application.DTOs.ProductDtos;
using Project.Application.Services;

namespace Project.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("/Products/All")]
        public async Task<ActionResult<IEnumerable<GetAllProductDto>>> GetAllProductAsync()
        {
            try
            {
                var products = await _productService.GetAllProductAsync();
                //if(products.IsNullOrEmpty())
                //{
                //    return Ok(products);
                //}
                return Ok(products);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }

        }

        [HttpGet("/Products/Critical/all")]
        public async Task<ActionResult<IEnumerable<GetAllCriticalProductsDto>>> GetAllCriticalProductAsync()
        {
            try
            {
                var products = await _productService.GetAllCriticalProductAsync();
                //if(products.IsNullOrEmpty())
                //{
                //    return Ok(products);
                //}
                return Ok(products);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpGet("/Products/Inventory")]
        public async Task<ActionResult<IEnumerable<GetInventoryListDto>>> GetAllInventoryListAsync()
        {
            try
            {
                var products = await _productService.GetAllInventoryListAsync();
                //if(products.IsNullOrEmpty())
                //{
                //    return Ok(products);
                //}
                return Ok(products);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpGet("/Products/Available")]
        public async Task<ActionResult<IEnumerable<GetAllAvailableProductsDto>>> GetAllAvailableProductsAsync()
        {
            try
            {
                var products = await _productService.GetAllAvailableProductsAsync();
                //if(products.IsNullOrEmpty())
                //{
                //    return Ok(products);
                //}
                return Ok(products);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpPost("/Product/AddProduct")]
        public async Task<IActionResult> AddProductAsync([FromBody] AddProductDto addProductDto)
        {
            try
            {
                await _productService.AddProductAsync(addProductDto);
                return NoContent();
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }

        }      

        [HttpPut("/Product/Update/{id}")]
        public async Task<IActionResult> UpdateProductAsync(Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (id != updateProductDto.ProductId) return BadRequest(new {error = "Id does not match!"});
            try
            {
                await _productService.UpdateProductAsync(updateProductDto);
                return NoContent();
            }
            catch(KeyNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (ArgumentNullException ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("/Product/Delete/{id}")]
        public async Task<IActionResult> DeleteProductSAsync(Guid id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return NoContent();

            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    StatusCode = 500,
                    Message = "An unexpected error occurred.",
                    Details = ex.Message
                });
            }
        }
    }
}
