using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndTreino.Context;
using BackEndTreino.Models;
using BackEndTreino.Filters;
using BackEndTreino.DTOs;
using AutoMapper;
using BackEndTreino.Repositories;
using BackEndTreino.Interfaces.Base;
using Microsoft.AspNetCore.Cors;

namespace BackEndTreino.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors ("CorsPolicy")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly AppDbContext _context;

        public CategoriesController(ICategoryService service, AppDbContext context)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Categories
        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categories = await _service.GetAll();
            return Ok(categories);
        }

        //[HttpGet("products")]
        //public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesProducts()
        //{
        //    return await _context.Categories.Include(p => p.Products).ToListAsync();
        //}


        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var category = await _service.GetById(id);
            return Ok(category);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDTO category)
        {
            var updatedCategory = await _service.Update(id, category);
            return Ok(updatedCategory);
        }


        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> PostCategory(CategoryDTO category)
        {
            var newCategory = await _service.Post(category);  
            return Ok(newCategory);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
