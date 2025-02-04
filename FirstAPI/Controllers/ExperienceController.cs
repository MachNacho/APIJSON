using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly FileHandler<Experience> _fileHandler;
        private readonly string filepath = "Data/JSON/Experience.json";
        public ExperienceController()
        {
            _fileHandler = new FileHandler<Experience>(filepath);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_fileHandler.ReadProductsFromFile());
        }
    }
}
