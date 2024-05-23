using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using BackEndTreino.Context;
using BackEndTreino.Domain.Repositories;
using BackEndTreino.Repositories;
using Core.Entitites.OrderAggregate;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace BackEndTreino.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepo _basketRepo;
        private readonly IProductRepo _productRepo;
        private readonly IDeliveryMethod _deliveryRepo;
        private readonly IOrderRepo _orderRepo;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public OrderService(IBasketRepo basketRepo, IProductRepo productRepo, IDeliveryMethod deliveryRepo, IOrderRepo orderRepo, AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _orderRepo = orderRepo;
            _deliveryRepo = deliveryRepo;
            _productRepo = productRepo;
            _basketRepo = basketRepo;
        }

        // public Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethod, string basketId, Address shippingAddress)
        // {
        //     throw new NotImplementedException();
        // }
        

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            var basket = await _basketRepo.GetById(basketId);

            var items = new List<OrderItem>();
            foreach(var item in basket.Items)
            {
                var productItem = await _productRepo.GetById(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.ImgUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity, productItem.Inventory);

                items.Add(orderItem);
            }

            var deliveryMethod = await _deliveryRepo.GetByIdAsync(deliveryMethodId);

            var subtotal = items.Sum(i => i.Price * i.Quantity);

            // check if order exists
            var order = await _orderRepo.GetByPayId(buyerEmail);

            if (order != null)
            {
                order.ShipToAddress = shippingAddress;
                order.DeliveryMethod = deliveryMethod;
                order.Subtotal = subtotal;
                order.OrderItems = items;
                _orderRepo.Update(order);
                return order;
            }
            else
            {
                order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal, basket.PaymentIntentId);
                _orderRepo.Update(order);
            }

            var result = await _context.SaveChangesAsync();
            if (result <= 0) return null;

            return order;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _orderRepo.GetAll();
        }

        public async Task<Order> GetOrderAsync(string buyerEmail)
        {
            return await _orderRepo.GetOrderAsync(buyerEmail);
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _deliveryRepo.GetAllAsync();
        }


        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var orderById = await _orderRepo.GetById(id);
            return _mapper.Map<OrderDto>(orderById);
        }

        async Task<IReadOnlyList<Order>> IOrderService.GetUsersOrdersAsync(string buyerEmail)
        {
            return await _orderRepo.GetUsersOrdersAsync(buyerEmail);
        }
    }
}