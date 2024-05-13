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
using BackEndTreino.Interfaces.Base;
using Microsoft.AspNetCore.Cors;

namespace BackEndTreino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors ("CorsPolicy")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _service;

        public BrandsController(IBrandService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetBrand()
        {
            var brands = await _service.GetAll();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDTO>> GetBrand(int id)
        {
            var brands = await _service.GetById(id);
            return Ok(brands);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, BrandDTO brand)
        {
            var updatedProduct = await _service.Update(id, brand);
            return Ok(updatedProduct);
        }

        [HttpPost]
        public async Task<IActionResult> PostBrand(BrandDTO brand)
        {
            var newBrand = await _service.Post(brand);
            return Ok(newBrand);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }

        //private bool BrandExists(int id)
        //{
        //    return _context.Brands.Any(e => e.Id == id);
        //}
    }
}
