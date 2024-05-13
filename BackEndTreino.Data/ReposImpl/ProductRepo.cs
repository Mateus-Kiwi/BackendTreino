using AutoMapper;
using BackEndTreino.Context;
using BackEndTreino.Domain.Pagination;
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
            if (products == null) { throw new Exception("No products found :("); }
            return products;
        }



        public async Task<Product> Post(Product product)
        {
            var brand = await _context.Brands!.FirstOrDefaultAsync(x => x.Id == product.BrandId);
            product.BrandName = brand?.Name;
            var category = await _context.Categories!.FirstOrDefaultAsync(x => x.Id == product.CategoryId);
            product.CategoryName = category?.Name;

            await _context.Products.AddAsync(product);
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

        public Task<IReadOnlyList<Product>> GetByBrand()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsPag(ProductsParams productsParams)
        {
            var startIndex = (productsParams.PageNumber - 1) * productsParams.PageSize;

            var products = await GetAll();

            var paginatedProducts = products.Skip(startIndex).Take(productsParams.PageSize);

            return paginatedProducts;
        }
    }
}
