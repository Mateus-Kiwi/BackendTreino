using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTreino.Repositories.Base;
using Core.Entitites.OrderAggregate;

namespace BackEndTreino.Domain.Repositories
{
    public interface IOrderRepo
    {
        Task<List<Order>> GetAll();
        void Update(Order order);
        void Add(Order order);
        Task<Order> Post(Order order);
        Task<Order> GetOrderAsync(string buyerEmail);
        Task<Order> GetByPayId(string paymentIntentId);
        Task<Order> GetById(int? id);
    }
}
