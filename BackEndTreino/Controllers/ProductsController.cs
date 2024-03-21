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
using System.Diagnostics;
using BackEndTreino.Repositories;

namespace BackEndTreino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProductRepo _productRepo;

        public ProductsController(AppDbContext context, IMapper mapper, IProductRepo productRepo)
        {
            _context = context;
            _mapper = mapper;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
        {
            var products = await _productRepo.GetAll();
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "ObtainProduct")]
        public async Task<ActionResult<ProductDTO>> GetProductAsync(int id)
        {
            var product = await _productRepo.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(Product product)
        {
            var newProduct =  await _productRepo.Post(product);
            return Ok(newProduct);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
                var updatedProduct = await _productRepo.Put(id, product);
                return Ok(updatedProduct);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepo.Delete(id);
            return NoContent();
        }


    }
}
