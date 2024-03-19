using AutoMapper;
using BackEndTreino.Context;
using BackEndTreino.DTOs;
using BackEndTreino.Models;
using BackEndTreino.Repositories;
using BackEndTreino.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BackEndTreino.ReposImpl
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();
            if (products == null) { throw new Exception("No products found :(");}
            return _mapper.Map <IEnumerable<ProductDTO>>(products);
        }

        

        public async Task <ProductDTO> Post(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return productDTO;
        }

        public async Task<ProductDTO> Put(int id, ProductDTO productDTO)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            _mapper.Map(productDTO, product);

            _context.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                throw new Exception("Product not found :(");
            }
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
