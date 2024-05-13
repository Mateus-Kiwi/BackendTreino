using AutoMapper;
using BackEndTreino.Context;
using BackEndTreino.Models;
using BackEndTreino.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace BackEndTreino.ReposImpl
{
    public class BrandRepo : IBrandRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BrandRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (brand == null)
            {
                throw new Exception("brand not found");
            }
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            var brands = await _context.Brands.AsNoTracking().ToListAsync();
            if (brands == null) { throw new Exception("No brands found :("); }
            return brands;
        }

        public async Task<Brand> GetById(int id)
        {
            var brand = await _context.Brands.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
            if (brand == null)
            {
                throw new Exception("brand not found :(");
            }
            return brand;
        }

        public async Task<Brand> Post(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<Brand> Put(int id, Brand brand)
        {
            var updatedBrand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);

            if (brand == null)
            {
                throw new Exception("brand not found");
            }

            updatedBrand.UpdateBrand(brand);

            _context.Entry(brand).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return brand;
        }
    }
}
