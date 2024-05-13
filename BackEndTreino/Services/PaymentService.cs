using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTreino.Domain.Models;
using BackEndTreino.Domain.Repositories;
using Core.Entitites.OrderAggregate;
using Core.Interfaces;

namespace BackEndTreino.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IBasketRepo _basketRepo;
        private readonly IConfiguration _config;
        public PaymentService(IBasketRepo basketRepo, IConfiguration config)
        {
            _config = config;
            _basketRepo = basketRepo;
        }

        public Task<Basket> CreateOrUpdatePaymentIntent(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderPaymentFailed(string paymentIntentId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId)
        {
            throw new NotImplementedException();
        }
    }
}