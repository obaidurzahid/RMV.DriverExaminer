using Microsoft.EntityFrameworkCore;
using RMV.DriverExaminer.Infrastructure.Data;
using RMV.DriverExaminer.Service.Interfaces.Repositories.Base;
using System.Net.Http;

namespace RMV.DriverExaminer.Infrastructure.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ApplicationDbContext _appDbContext;

        public RepositoryBase(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public List<T> GetAll()
        {
            var list = _appDbContext.Set<T>().ToList();
            return list;
        }

        public T GetById(long id)
        {
            var result= _appDbContext.Set<T>().Find(id);
            return result;
        }
        public int Add(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
            var result = _appDbContext.SaveChanges();
            return result;
        }

        public int Update(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            var result = _appDbContext.SaveChanges();
            return result;
        }
        public int Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            return _appDbContext.SaveChanges();
        }
    }
}
