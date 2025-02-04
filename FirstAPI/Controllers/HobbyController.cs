using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("[controller]")] // Set route
    [ApiController] // Bring in apicontroller
    public class HobbyController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }
    }
}
