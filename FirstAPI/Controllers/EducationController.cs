using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("[controller]")] // Set route
    [ApiController] // Bring in apicontroller
    public class EducationController : ControllerBase
    {
        private readonly FileHandler<Hobby> _fileHandler;
        private readonly string filepath = "Data/JSON/Hobby.json";
        public EducationController()
        {
            _fileHandler = new FileHandler<Hobby>(filepath);
        }

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
