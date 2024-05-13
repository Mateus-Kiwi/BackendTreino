using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTreino.Domain.Models;
using BackEndTreino.Repositories.Base;

namespace BackEndTreino.Domain.Repositories
{
    public interface IBasketRepo
    {
        Task<Basket> GetById(string id);
        Task<Basket> Update(Basket type);
        Task Delete(string id);
    }
}