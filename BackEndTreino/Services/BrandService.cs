using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackEndTreino.DTOs;
using BackEndTreino.Interfaces.Base;
using BackEndTreino.Models;
using BackEndTreino.Repositories;

namespace BackEndTreino.Services
{
    public class BrandService : IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepo _repo;
        public BrandService(IBrandRepo repo, IMapper mapper)
        {
           _repo = repo;
           _mapper = mapper;
        }

        public async Task<IEnumerable<BrandDTO>> GetAll()
        {
            var brandEs = await _repo.GetAll();
            return _mapper.Map<IEnumerable<BrandDTO>>(brandEs);
        }

        public async Task<BrandDTO> GetById(int id)
        {
            var brandE = await _repo.GetById(id);
            return _mapper.Map<BrandDTO>(brandE);
        }

        public async Task<BrandDTO> Post(BrandDTO brandDTO)
        {
            var brandE = _mapper.Map<Brand>(brandDTO);
            await _repo.Post(brandE);
            return brandDTO;
        }

        public async Task<BrandDTO> Update(int id, BrandDTO brandDTO)
        {
            var brandE = _mapper.Map<Brand>(brandDTO);
            await _repo.Put(id, brandE);
            return brandDTO;
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }
    }
}