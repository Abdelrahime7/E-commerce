namespace Application.Interfaces.Generic
{
    public interface IGenericRepository <T> where T : class
    {
       Task< IEnumerable<T>> GetAllAsync();
       Task <T>GetByIDAsync(int id);
        Task <int> AddAsync(T entity);
        Task <bool> UpdateAsync( T entity);
        Task <bool> DeleteAsync(int id);
        Task<int> SoftDeleteAsync(int id);

    }
}
