using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly FileHandler<Project> _fileHandler;
        private readonly ApplicationDBContext _context;
        private readonly string filepath = "Data/JSON/Project.json";
        public ProjectsController(ApplicationDBContext context)
        {
            _fileHandler = new FileHandler<Project>(filepath);
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.projects.ToList());
        }
    }
}
