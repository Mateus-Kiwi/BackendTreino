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

namespace BackEndTreino.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICategoryRepo _categoryRepo;

        public CategoriesController(AppDbContext context,  ICategoryRepo categoryRepo, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
            _categoryRepo = categoryRepo;
        }

        // GET: api/Categories
        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoryRepo.GetAll();
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
            var category = await _categoryRepo.GetById(id);
            return Ok(category);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDTO categoryDTO)
        {
            var updatedCategory = await _categoryRepo.Put(id, categoryDTO);
            return Ok(updatedCategory);
        }


        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> PostCategory(CategoryDTO categoryDTO)
        {
            var newCategory = await _categoryRepo.Post(categoryDTO);  
            return Ok(newCategory);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepo.Delete(id);
            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
