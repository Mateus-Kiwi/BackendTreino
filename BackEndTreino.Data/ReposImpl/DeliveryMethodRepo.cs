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
    public class DeliveryMethodRepo : IDeliveryMethod
    {
        private readonly AppDbContext _context;
        public DeliveryMethodRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetAllAsync()
        {
            var deliveryMethods = await _context.DeliveryMethods.AsNoTracking().ToListAsync();
            if (deliveryMethods == null) { throw new Exception("No deliveryMethods found :("); }
            return deliveryMethods;
        }

        public async Task<DeliveryMethod> GetByIdAsync(int id)
        {
            var deliveryMethod = await _context.DeliveryMethods.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            if (deliveryMethod == null)
            {
                throw new Exception("deliveryMethod not found :(");
            }
            return deliveryMethod;
        }
    }
}