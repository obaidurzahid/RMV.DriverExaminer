using RMV.DriverExaminer.Service.Models;
using RMV.DriverExaminer.Domain.Common;

namespace RMV.DriverExaminer.Service.Interfaces
{
    public interface ISampleService
    {
        Task<List<SampleModel>> GetSamples();
        Task<SampleModel> GetSampleById(long id);
        Task<Response> CreateSample(SampleModel sample);
    }
}
