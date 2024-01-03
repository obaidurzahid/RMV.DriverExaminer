namespace RMV.DriverExaminer.Service.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> GetAll();
        T GetById(long id);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
