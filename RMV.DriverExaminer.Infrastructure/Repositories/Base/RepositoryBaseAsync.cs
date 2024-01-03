using Microsoft.EntityFrameworkCore;
using RMV.DriverExaminer.Infrastructure.Data;
using RMV.DriverExaminer.Service.Interfaces.Repositories.Base;
using System.Net.Http;

namespace RMV.Infrastructure.Repositories.Base
{
    public class RepositoryBaseAsync<T> : IRepositoryBaseAsync<T> where T : class
    {
        protected readonly ApplicationDbContext _appDbContext;

        public RepositoryBaseAsync(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public async Task<List<T>> GetAllAsync()
        {
            try {
                var list = await _appDbContext.Set<T>().ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
            
        }

        public async Task<T> GetByIdAsync(long id)
        {
            var result= await _appDbContext.Set<T>().FindAsync(id);
            return result;
        }
        public async Task<int> AddAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            var result = await _appDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            var result = await _appDbContext.SaveChangesAsync();
            return result;
        }
        public async Task<int> DeleteAsync(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
