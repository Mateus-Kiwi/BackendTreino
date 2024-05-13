
using BackEndTreino.Domain.Pagination;
using BackEndTreino.Models;
using BackEndTreino.Repositories.Base;

namespace BackEndTreino.Repositories
{
    public interface IProductRepo : IBaseRepo<Product>
    {
        Task<IEnumerable<Product>> GetProductsPag(ProductsParams productsParams);
        Task<IReadOnlyList<Product>> GetByBrand();
    }
}
