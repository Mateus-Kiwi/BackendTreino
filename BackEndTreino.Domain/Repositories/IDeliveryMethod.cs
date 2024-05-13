using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTreino.Repositories.Base;
using Core.Entitites.OrderAggregate;

namespace BackEndTreino.Domain.Repositories
{
    public interface IDeliveryMethod

    {
        Task<DeliveryMethod> GetByIdAsync(int id);
        Task<IReadOnlyList<DeliveryMethod>> GetAllAsync();
    }
}