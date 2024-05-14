using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTreino.Domain.Models;
using BackEndTreino.Domain.Repositories;
using BackEndTreino.ReposImpl;
using BackEndTreino.Repositories;
using Core.Entitites.OrderAggregate;
using Core.Interfaces;
using Stripe;

namespace BackEndTreino.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IBasketRepo _basketRepo;
        private readonly IConfiguration _config;
        private readonly IProductRepo _productRepo;
        public PaymentService(IBasketRepo basketRepo, IConfiguration config, IProductRepo productRepo)
        {
            _productRepo = productRepo;
            _config = config;
            _basketRepo = basketRepo;
        }

        public async Task<Basket> CreateOrUpdatePaymentIntent(string basketId)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SercretKey"];
            var basket = await _basketRepo.GetById(basketId);
            var shippingPrice = 10m;
            basket.DeliveryMethodId = 1; 

            foreach (var item in basket.Items) 
            {
                var productItem = await _productRepo.GetById(item.Id);
                if (item.Price != productItem.Price)
                {
                    item.Price = productItem.Price;
                }
            }
            var service = new PaymentIntentService();

            PaymentIntent intent;

            if (string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long) basket.Items.Sum(i=> i.Quantity *(i.Price * 100)) + (long) 
                    shippingPrice * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> {"card"}
                };
                intent = await service.CreateAsync(options);
                basket.PaymentIntentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;
            }
            else 
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long) basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long)
                    shippingPrice * 100
                };
                await service.UpdateAsync(basket.PaymentIntentId, options);
            }

            await _basketRepo.Update(basket);

            return basket;
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