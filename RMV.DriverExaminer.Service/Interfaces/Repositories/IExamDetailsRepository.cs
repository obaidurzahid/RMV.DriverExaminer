using RMV.DriverExaminer.Domain.Entities;
using RMV.DriverExaminer.Service.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMV.DriverExaminer.Service.Interfaces.Repositories
{
    public interface IExamDetailsRepository : IRepositoryBaseAsync<ExamDetails>
    {
        //custom operations here
        //Task<ExamDetails?> GetExamData(string masterNumber);
        Task<PublicApis> GetExamData(string masterNumber);
    }
}
