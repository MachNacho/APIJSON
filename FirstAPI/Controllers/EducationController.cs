using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("[controller]")] // Set route
    [ApiController] // Bring in apicontroller
    public class EducationController : ControllerBase
    {
        private readonly FileHandler<Education> _fileHandler;
        private readonly string filepath = "Data/JSON/Education.json";
        public EducationController()
        {
            _fileHandler = new FileHandler<Education>(filepath);
        }

        [HttpGet] // Get request
        public IActionResult GetAll()
        {
            return Ok(_fileHandler.ReadProductsFromFile());
        }
    }
}
