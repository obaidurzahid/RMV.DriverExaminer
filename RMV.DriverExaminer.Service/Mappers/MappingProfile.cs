using AutoMapper;
using RMV.DriverExaminer.Service.Models;
using RMV.DriverExaminer.Domain.Entities;


namespace RMV.DriverExaminer.Application.Mapper
{
    public class MappingProfile : Profile
    {
        //https://code-maze.com/automapper-net-core/
        //https://docs.automapper.org/en/stable/Getting-started.html
        public MappingProfile()
        {
            //CreateMap<Sample, SampleModel>().ReverseMap();

            CreateMap<Sample, SampleModel>()
                .ForMember(dest =>
                    dest.Code,
                    opt => opt.MapFrom(src => src.EmployeeCode))
            .ReverseMap();

            CreateMap<ExamDetails, ExamDetailsModel>()
                .ForMember(dest =>
                    dest.DEFullName,
                    opt => opt.MapFrom(src => src.DEName))
            .ReverseMap();

            CreateMap<PublicApis, PublicApisModel>().ReverseMap();
            CreateMap<ApiEntries, ApiEntriesModel>().ReverseMap();

        }   

    }
}
