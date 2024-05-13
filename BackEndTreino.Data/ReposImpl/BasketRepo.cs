using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BackEndTreino.Domain.Models;
using BackEndTreino.Domain.Repositories;
using StackExchange.Redis;

namespace BackEndTreino.Data.ReposImpl
{
    public class BasketRepo : IBasketRepo
    {
        private readonly IDatabase _database;
        public BasketRepo(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task Delete(string id)
        {
            await _database.KeyDeleteAsync(id);
        }

        public async Task<Basket> GetById(string id)
        {
            var basket = await _database.StringGetAsync(id);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Basket>(basket);
        }

        public async Task<Basket> Update(Basket basket)
        {
            var updatedBasket  = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(7));
            return await GetById(basket.Id);
        }
    }
}