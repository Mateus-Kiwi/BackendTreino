using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using Core.Entitites.OrderAggregate;

namespace BackEndTreino.Domain.Repositories
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();
        Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethod, string basketId, Address shippingAddress);
        Task<OrderDto> GetOrderByIdAsync(int id);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
        Task<Order> GetOrderAsync(string buyerEmail);
        Task<IReadOnlyList<Order>> GetUsersOrdersAsync(string buyerEmail);
    }
}