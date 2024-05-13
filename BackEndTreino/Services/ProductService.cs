using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackEndTreino.Domain.Pagination;
using BackEndTreino.DTOs;
using BackEndTreino.Interfaces;
using BackEndTreino.Models;
using BackEndTreino.Repositories;


namespace BackEndTreino.Services
{ 
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepo _repo;
        public ProductService(IProductRepo repo, IMapper mapper)
        {
           _repo = repo;
           _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var productEs = await _repo.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(productEs);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var productE = await _repo.GetById(id);
            return _mapper.Map<ProductDTO>(productE);
        }

        public async Task<ProductDTO> Post(ProductDTO productDTO)
        {
            var productE = _mapper.Map<Product>(productDTO);
            await _repo.Post(productE);
            return productDTO;
        }

        public async Task<ProductDTO> Update(int id, ProductDTO productDTO)
        {
            var productE = _mapper.Map<Product>(productDTO);
            await _repo.Put(id, productE);
            return productDTO;
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsPag(ProductsParams productsParams)
        {
            var productEs = await _repo.GetProductsPag(productsParams);
            return _mapper.Map<IEnumerable<ProductDTO>>(productEs);
        }
    }
}