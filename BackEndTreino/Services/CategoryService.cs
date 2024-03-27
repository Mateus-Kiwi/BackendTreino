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
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepo _repo;
        public CategoryService(ICategoryRepo repo, IMapper mapper)
        {
           _repo = repo;
           _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var categoryEs = await _repo.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoryEs);
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var categoryE = await _repo.GetById(id);
            return _mapper.Map<CategoryDTO>(categoryE);
        }

        public async Task<CategoryDTO> Post(CategoryDTO categoryDTO)
        {
            var categoryE = _mapper.Map<Category>(categoryDTO);
            await _repo.Post(categoryE);
            return categoryDTO;
        }

        public async Task<CategoryDTO> Update(int id, CategoryDTO categoryDTO)
        {
            var categoryE = _mapper.Map<Category>(categoryDTO);
            await _repo.Put(id, categoryE);
            return categoryDTO;
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }
    }
}