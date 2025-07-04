using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resilience_InActionWithPolly.Services;

namespace Resilience_InActionWithPolly.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalApiController : ControllerBase
    {
        private readonly ExternalApiService _service;

        public ExternalApiController(ExternalApiService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetDataAsync();
            return Ok(data);
        }
    }
}
