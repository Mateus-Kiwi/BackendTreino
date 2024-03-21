using AutoMapper;
using BackEndTreino.Context;
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

        

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();
            if (products == null) { throw new Exception("No products found :(");}
            return products;
        }

        

        public async Task <Product> Post(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Put(int id, Product product)
        {
            var updatedProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            updatedProduct.UpdateProduct(product);

            _context.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                throw new Exception("Product not found :(");
            }
            return product;
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
