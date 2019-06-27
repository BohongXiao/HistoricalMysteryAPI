using System.Collections.Generic;
using System.Threading.Tasks;
using HM.Common.Utils;
using HM.Interfaces.IServices;
using HM.Interfaces.IUtils;
using Microsoft.AspNetCore.Mvc;

namespace HistoricalMysteryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILoggingService _log;
        private readonly ITestService _service;

        public ValuesController(ILoggingService log, ITestService service)
        {
            _log = log;
            _service = service;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            _log.Info($"First log from DI!!!");
            var message = await _service.TestAsync("Love you.").Caf();
            return new[] { "message", $"{message}" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
