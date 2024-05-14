using AutoMapper;
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
        private readonly IMapper _mapper;
        public BasketController(IBasketRepo service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BasketDTO>> GetBasketAsync(string id)
        {
            var basket = await _service.GetById(id);
            return Ok(basket);
        }



        [HttpPut("{id}")]
        //TALVEZ BUGADO
        public async Task<IActionResult> UpdateBasketAsync(Basket basketDTO)
        {
            var basket = await _service.Update(basketDTO);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> UpdateBasket(BasketDTO basket)
        {
            var customerBasket = _mapper.Map<BasketDTO, Basket>(basket);
            var uppdatedBasket = await _service.Update(customerBasket);
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