using Microsoft.EntityFrameworkCore;
using RMV.DriverExaminer.Domain.Entities;
using RMV.DriverExaminer.Infrastructure.Data;
using RMV.Infrastructure.Repositories.Base;
using RMV.DriverExaminer.Service.Interfaces.Repositories;

namespace RMV.Infrastructure.Repositories
{

    public class SampleRepository : RepositoryBaseAsync<Sample>, ISampleRepository
    {
        public SampleRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {

        }
        //custom operations here
        public async Task<Sample> GetSampleByCode(string code)
        {
            var model = await _appDbContext.Sample
                .Where(m => m.EmployeeCode == code).FirstAsync();

            return model;
        }
    }
}
