using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace React_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Default API Controller Newly Loaded");
        }
    }
}
