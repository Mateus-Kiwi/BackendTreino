using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTreino.Domain.Pagination;
using BackEndTreino.DTOs;
using BackEndTreino.Interfaces.Base;

namespace BackEndTreino.Interfaces
{
    public interface IProductService : IBaseService<ProductDTO>
    {
        Task<IEnumerable<ProductDTO>> GetProductsPag(ProductsParams productsParams);
    }
}