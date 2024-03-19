using AutoMapper;
using BackEndTreino.Context;
using BackEndTreino.DTOs;
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

        public async Task<IEnumerable<BrandDTO>> GetAll()
        {
            var brands = await _context.Brands.AsNoTracking().ToListAsync();
            if (brands == null) { throw new Exception("No brands found :("); }
            return _mapper.Map<IEnumerable<BrandDTO>>(brands);
        }

        public async Task<BrandDTO> GetById(int id)
        {
            var brand = await _context.Brands.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
            if (brand == null)
            {
                throw new Exception("brand not found :(");
            }
            return _mapper.Map<BrandDTO>(brand);
        }

        public async Task<BrandDTO> Post(BrandDTO brandDTO)
        {
            var brand = _mapper.Map<Brand>(brandDTO);

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brandDTO;
        }

        public async Task<BrandDTO> Put(int id, BrandDTO brandDTO)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);

            if (brand == null)
            {
                throw new Exception("brand not found");
            }

            _mapper.Map(brandDTO, brand);

            _context.Entry(brand).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return _mapper.Map<BrandDTO>(brand);
        }
    }
}
