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
    public class SampleService : ISampleService
    {
        public ISampleRepository _sampleRepository;
        public IMapper _mapper;

        public SampleService(ISampleRepository sampleRepository, IMapper mapper)
        {
            _sampleRepository = sampleRepository ?? throw new ArgumentNullException(nameof(sampleRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<SampleModel>> GetSamples()
        {
            //throw new NotImplementedException();
            var list = await _sampleRepository.GetAllAsync();
            
            var modelList = _mapper.Map<List<SampleModel>>(list);
            return modelList;
        }
        public async Task<SampleModel> GetSampleById(long id)
        {
            var domainEntity = await _sampleRepository.GetByIdAsync(id);
            var model = _mapper.Map<SampleModel>(domainEntity);
            return model;
        }

        public async Task<Response> CreateSample(SampleModel sample)
        {
            var domainEntity = _mapper.Map<Sample>(sample);
            var result = await _sampleRepository.AddAsync(domainEntity);
            var response = CommonLogics.GetAddResponse(result, "Sample");
            return response;
        }

        public async Task<Response> UpdateSample(SampleModel sample)
        {
            var domainEntity = _mapper.Map<Sample>(sample);
            var result = await _sampleRepository.UpdateAsync(domainEntity);
            var response = CommonLogics.GetUpdateResponse(result, "Sample");
            return response;
        }

        public async Task<Response> DeleteSample(SampleModel sample)
        {
            var domainEntity = _mapper.Map<Sample>(sample);
            var result = await _sampleRepository.DeleteAsync(domainEntity);
            var response = CommonLogics.GetDeleteResponse(result, "Sample");
            return response;
        }
        public async Task<SampleModel> GetSampleByCode(string code)
        {
            var domainEntity = await _sampleRepository.GetSampleByCode(code);
            var model = _mapper.Map<SampleModel>(domainEntity);
            return model;
        }
    }
}
