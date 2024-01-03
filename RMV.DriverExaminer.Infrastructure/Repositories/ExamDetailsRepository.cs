using RMV.DriverExaminer.Domain.Entities;
using RMV.DriverExaminer.Infrastructure.Common;
using RMV.DriverExaminer.Infrastructure.Data;
using RMV.DriverExaminer.Service.Interfaces.Repositories;
using RMV.Infrastructure.Repositories.Base;


namespace RMV.DriverExaminer.Infrastructure.Repositories
{
    public class ExamDetailsRepository : RepositoryBaseAsync<ExamDetails>, IExamDetailsRepository
    {
        private readonly IRMV3AppClient _rmv3AppClient;
        public ExamDetailsRepository(ApplicationDbContext appDbContext, IRMV3AppClient rmv3AppClient) : base(appDbContext)
        {
            _rmv3AppClient = rmv3AppClient ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        
        public async Task<PublicApis> GetExamData(string masterNumber)
        {
            CancellationTokenSource tokenSrc = new CancellationTokenSource();
            //tokenSrc.CancelAfter(TimeSpan.FromSeconds(50));

            var response = await _rmv3AppClient.GetData("/random", tokenSrc.Token);
            dynamic result = await response.ReadHttpContent<PublicApis>();
            //var result = JsonSerializer.Deserialize<dynamic>(resultObj.ToString());

            return result;
        }
    }
}
