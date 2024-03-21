
using AutoMapper;
using BackEndTreino.Context;
using BackEndTreino.Models;
using BackEndTreino.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackEndTreino.ReposImpl
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await _context.Categories.AsNoTracking().ToListAsync();
            if (categories == null) { throw new Exception("No categories found :("); }
            return categories;
        }

        public async Task<Category> GetById(int id)
        {
            var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            if (category == null)
            {
                throw new Exception("Category not found :(");
            }
            return category;
        }

        public async Task<Category> Post(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Put(int id, Category category)
        {
            var updatedCategory = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            updatedCategory.UpdateCategory(category);

            _context.Entry(category).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return category;
        }
    }
}
