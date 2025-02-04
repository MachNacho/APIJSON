using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("[controller]")] // Set route
    [ApiController] // Bring in apicontroller
    public class EducationController : ControllerBase
    {
        [HttpGet] // Get request
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
