using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly FileHandler<Project> _fileHandler;
        private readonly string filepath = "Data/JSON/Project.json";
        public ProjectsController()
        {
            _fileHandler = new FileHandler<Project>(filepath);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_fileHandler.ReadProductsFromFile());
        }
    }
}
