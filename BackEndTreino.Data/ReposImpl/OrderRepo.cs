using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTreino.Context;
using BackEndTreino.Domain.Repositories;
using Core.Entitites.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace BackEndTreino.Data.ReposImpl
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;
        private readonly IBasketRepo _basketRepo;
        public OrderRepo(AppDbContext context, IBasketRepo basketRepo)
        {
            _context = context;
            _basketRepo = basketRepo;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public async void Add(Order order)
        {
            await _context.Set<Order>().AddAsync(order);
        }

        public async Task<Order> Post(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetById(int? id)
        {
            var orderById = await _context.Orders!.FirstOrDefaultAsync(o => o.Id == id);
            if (orderById == null) throw new Exception($"Order with Id {id} was not found.");

            return orderById;
        }

        public async Task<Order> GetOrderAsync(string buyerEmail)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.DeliveryMethod)
                .FirstOrDefaultAsync(o => o.BuyerEmail == buyerEmail);

            return order;
        }

        public async Task<Order> GetByPayId(string paymentIntentId)
        {
            return await _context.Orders
                .FirstOrDefaultAsync(o => o.PaymentIntentId == paymentIntentId);
        }

        public async Task<IReadOnlyList<Order>> GetUsersOrdersAsync(string buyerEmail)
        {
            return await _context.Orders
            .Where(o => o.BuyerEmail == buyerEmail)
            .ToListAsync();
        }

    }
}