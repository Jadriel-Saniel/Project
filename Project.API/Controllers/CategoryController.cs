﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Application.DTOs;
using Project.Application.Services;

namespace Project.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/Categories/All")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategoryAsync()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoryAsync();
                return Ok(categories);
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

        [HttpPost("/Category/AddCategory")]
        public async Task<IActionResult> AddCategoryAsync([FromBody] CategoryInfoDto categoryInfoDto)
        {
            try
            {
                await _categoryService.AddCategoryAsync(categoryInfoDto);
                return Ok(categoryInfoDto);

            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(new {error = ex.Message});
            }
            
        }

    }
}
