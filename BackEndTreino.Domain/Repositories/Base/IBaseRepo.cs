
namespace BackEndTreino.Repositories.Base
{
    public interface IBaseRepo<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Post(T type);
        Task<T> Put(int id, T type);
        Task Delete(int id);
    }
}
