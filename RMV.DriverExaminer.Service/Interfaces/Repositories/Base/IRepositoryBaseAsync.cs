namespace RMV.DriverExaminer.Service.Interfaces.Repositories.Base
{
    public interface IRepositoryBaseAsync<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
