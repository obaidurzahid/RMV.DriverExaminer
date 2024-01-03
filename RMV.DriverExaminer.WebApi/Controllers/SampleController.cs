using Microsoft.AspNetCore.Mvc;
using RMV.DriverExaminer.Service.Models;
using RMV.DriverExaminer.Service.Interfaces;
using System.Net.Http;


//https://www.strathweb.com/2020/10/beautiful-and-compact-web-apis-with-c-9-net-5-0-and-asp-net-core/

namespace RMV.DriverExaminer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ICustomLogger<SampleController> _logger;

        private readonly ISampleService _sampleService;
        public SampleController(ISampleService sampleService, ICustomLogger<SampleController> logger)
        {
            _sampleService = sampleService ?? throw new ArgumentNullException(nameof(sampleService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/Sample
        [HttpGet]
        public async Task<IActionResult> GetSamples()
        {
            var list = await _sampleService.GetSamples();

            _logger.Information("***RMV Logging Test");

            if(list == null)
            {
                //Global Error handaling check
                throw new ApplicationException();
            }
            return Ok(list);

        }

        // GET: api/Sample/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSample(long id)
        {
            var customer = await _sampleService.GetSampleById(id);
            return Ok(customer);
        }

        //// POST: api/Sample
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> CreateSample([FromBody] SampleModel customer)
        {
            var response = await _sampleService.CreateSample(customer);

            return Ok(response);
        }
    }
}
