using BackEndTreino.Domain.Models;
using BackEndTreino.Domain.Repositories;
using BackEndTreino.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEndTreino.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors ("CorsPolicy")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepo _service;
        public BasketController(IBasketRepo service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BasketDTO>> GetBasketAsync(string id)
        {
            var basket = await _service.GetById(id);
            return Ok(basket);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBasketAsync(Basket basketDTO)
        {
            var basket = await _service.Update(basketDTO);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> UpdateBasket(Basket basket)
        {
            var uppdatedBasket = await _service.Update(basket);
            return Ok(uppdatedBasket);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasketAsync(string id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}