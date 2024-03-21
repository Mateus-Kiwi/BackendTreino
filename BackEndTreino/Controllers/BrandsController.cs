using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndTreino.Context;
using BackEndTreino.Models;
using BackEndTreino.DTOs;
using AutoMapper;
using BackEndTreino.Repositories;
using BackEndTreino.ReposImpl;

namespace BackEndTreino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IBrandRepo _brandRepo;

        public BrandsController(AppDbContext context, IMapper mapper, IBrandRepo brandRepo)
        {
            _context = context;
            _mapper = mapper;
            _brandRepo = brandRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrand()
        {
            var brands = await _brandRepo.GetAll();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            var brands = await _brandRepo.GetById(id);
            return Ok(brands);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, Brand brand)
        {
            var updatedProduct = await _brandRepo.Put(id, brand);
            return Ok(updatedProduct);
        }

        [HttpPost]
        public async Task<IActionResult> PostBrand(Brand brand)
        {
            var newBrand = await _brandRepo.Post(brand);
            return Ok(newBrand);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _brandRepo.Delete(id);
            return NoContent();
        }

        //private bool BrandExists(int id)
        //{
        //    return _context.Brands.Any(e => e.Id == id);
        //}
    }
}
