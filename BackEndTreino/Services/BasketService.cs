using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackEndTreino.Domain.Models;
using BackEndTreino.Domain.Repositories;
using BackEndTreino.DTOs;
using BackEndTreino.Interfaces;

namespace BackEndTreino.Services
{
    public class BasketService : IBasketService
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepo _repo;
        public BasketService(IBasketRepo repo, IMapper mapper)
        {
           _repo = repo;
           _mapper = mapper;
        }

        public async Task Delete(string id)
        {
            await _repo.Delete(id);
        }

        public async Task<BasketDTO> GetById(string id)
        {
            var basketE = await _repo.GetById(id);
            return _mapper.Map<BasketDTO>(basketE);
        }

        public async Task<BasketDTO> Update(BasketDTO basketDTO)
        {
            var basketE = _mapper.Map<Basket>(basketDTO);
            await _repo.Update(basketE);
            return basketDTO;
        }
        
    }
}