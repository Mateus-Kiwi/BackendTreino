using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndTreino.Interfaces.Base
{
    public interface IBaseService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Post(T type);
        Task<T> Update(int id, T type);
        Task Delete(int id);
    }
}