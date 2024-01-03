using Microsoft.AspNetCore.Mvc;
using RMV.DriverExaminer.Domain.Entities;
using RMV.DriverExaminer.Infrastructure.Common;
using RMV.DriverExaminer.Service.Interfaces;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RMV.DriverExaminer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamDetailsController : ControllerBase
    {
        private readonly ICustomLogger<ExamDetailsController> _logger;

        private readonly IExamDetailsService _examDetailsService;
        private readonly IRMV3AppClient _httpClient;

        public ExamDetailsController(IExamDetailsService examDetailsService, ICustomLogger<ExamDetailsController> logger, IRMV3AppClient httpClient)
        {
            _examDetailsService = examDetailsService ?? throw new ArgumentNullException(nameof(examDetailsService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient = httpClient;   
        }

        // GET: api/<ExamDetailsController>
        [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ExamDetailsController>/5
        // [HttpGet("{code}")]
        [HttpGet()]
        public async Task<ActionResult> GetExamData()//(string code
        {
            var result = await _examDetailsService.GetExamData("");
            return Ok(result);
        }

        // POST api/<ExamDetailsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        
    }
}
