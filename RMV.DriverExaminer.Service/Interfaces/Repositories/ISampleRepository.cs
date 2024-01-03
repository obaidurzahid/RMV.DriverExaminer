using RMV.DriverExaminer.Domain.Entities;
using RMV.DriverExaminer.Service.Interfaces.Repositories.Base;

namespace RMV.DriverExaminer.Service.Interfaces.Repositories
{
    public interface ISampleRepository : IRepositoryBaseAsync<Sample>
    {
        //custom operations here
        Task<Sample> GetSampleByCode(string code);
    }
}
