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
using BackEndTreino.Interfaces;
using BackEndTreino.Domain.Pagination;
using Microsoft.AspNetCore.Cors;

namespace BackEndTreino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors ("CorsPolicy")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync()
        {
            var products = await _service.GetAll();
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "ObtainProduct")]
        public async Task<ActionResult<ProductDTO>> GetProductAsync(int id)
        {
            var product = await _service.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductDTO product)
        {
            await _service.Post(product);
            return Ok(product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutProduct(int id, ProductDTO product)
        {
            var updatedProduct = await _service.Update(id, product);
            return Ok(updatedProduct);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetProductsPag([FromQuery] ProductsParams productsParams)
        {
            var products = await _service.GetProductsPag(productsParams);
            return Ok(products);
        }

    }
}
