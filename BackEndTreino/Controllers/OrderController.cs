using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using BackEndTreino.Context;
using BackEndTreino.Domain.Repositories;
using BackEndTreino.DTOs;
using Core.Entitites.OrderAggregate;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;

namespace BackEndTreino.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;


        public OrderController(IOrderService service, IMapper mapper, AppDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAll();
            if (orders == null) return NotFound("No orders were found.");
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            var order = await _service.GetOrderByIdAsync(id);
            if (order == null) return NotFound($"Order with Id {id} not found.");
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
        
            var address = _mapper.Map<AddressDTO, Address>(orderDto.ShipToAddress);

            var order = await _service.CreateOrderAsync(orderDto.BuyerEmail, orderDto.DeliveryMethodId, orderDto.basketId, address);

            if (order == null) return BadRequest();

            var order1 = await _service.GetOrderAsync(orderDto.BuyerEmail);

            foreach (var item in order1.OrderItems)
            {
                var product = await _context.Products.FindAsync(item.ItemOrdered.ProductItemId);

                if (product != null)
                {
                    product.Inventory -= item.Quantity;
                }
                else
                {
                    return NotFound($"Product with ID {item.Id} not found.");
                }
            }

            await _context.SaveChangesAsync();
            return Ok(order);
        }
    }
}