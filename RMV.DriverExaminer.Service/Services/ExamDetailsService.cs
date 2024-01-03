using AutoMapper;
using RMV.DriverExaminer.Domain.Common;
using RMV.DriverExaminer.Domain.Entities;
using RMV.DriverExaminer.Service.Interfaces;
using RMV.DriverExaminer.Service.Interfaces.Repositories;
using RMV.DriverExaminer.Service.Models;
using RMV.DriverExaminer.Service.Utilities;
using System.Net.Http;


namespace RMV.DriverExaminer.Service.Services
{
    public class ExamDetailsService : IExamDetailsService
    {
        public IExamDetailsRepository _examDetailsRepository;
        public IMapper _mapper;

        public ExamDetailsService(IExamDetailsRepository examDetailsRepository, IMapper mapper)
        {
            _examDetailsRepository = examDetailsRepository ?? throw new ArgumentNullException(nameof(examDetailsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<ExamDetailsModel>> GetExamDataAll()
        {
            var results = await _examDetailsRepository.GetAllAsync();
            var list = _mapper.Map<List<ExamDetailsModel>>(results);
            return list;
        }
        public async Task<ApiEntriesModel> GetExamData(string code)
        {
            var list = await _examDetailsRepository.GetExamData(code);

            var modelList = _mapper.Map<List<ApiEntriesModel>>(list.entries);
            return modelList.FirstOrDefault();
        }
        //public async Task<ExamDetailsModel?> GetExamData(string code)
        //{
        //    var list = await _examDetailsRepository.GetExamData(code);

        //    var modelList = _mapper.Map<List<ExamDetailsModel>>(list);
        //    return modelList?.FirstOrDefault();
        //}
        public Task<Response> CreateExamData(ExamDetails examDetails)
        {
            throw new NotImplementedException();
        }

    }  
}
