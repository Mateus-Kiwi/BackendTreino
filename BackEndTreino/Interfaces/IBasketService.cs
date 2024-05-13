using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTreino.Domain.Models;
using BackEndTreino.DTOs;

namespace BackEndTreino.Interfaces
{
    public interface IBasketService
    {
        Task<BasketDTO> GetById(string id);
        Task<BasketDTO> Update(BasketDTO type);
        Task Delete(string id);
    }
}