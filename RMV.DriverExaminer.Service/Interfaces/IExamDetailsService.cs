using RMV.DriverExaminer.Service.Models;
using RMV.DriverExaminer.Domain.Common;
using RMV.DriverExaminer.Domain.Entities;

namespace RMV.DriverExaminer.Service.Interfaces
{
    public interface IExamDetailsService
    {
        Task<List<ExamDetailsModel>> GetExamDataAll();
        //Task<ExamDetails> GetExamData(string code);
        Task<ApiEntriesModel> GetExamData(string code);
        Task<Response> CreateExamData(ExamDetails examDetails);
    }
}
