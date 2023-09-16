using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StageTT.Controllers
{
    
    [ApiController]
    public class ApiController : ControllerBase
    {
        [Route("/api")]
        [HttpGet]   
        public IActionResult get()
        {
            return Ok("This Api is active");
        }
    }
}
