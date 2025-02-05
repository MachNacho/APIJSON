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
        [HttpGet("{ID}")]
        public IActionResult GetByID(int ID)
        {
            var projectList = _fileHandler.ReadProductsFromFile();
            var project = projectList.Find(p => p.ID == ID);
            if (project == null) return NotFound();
            return Ok(project);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Project project)
        {
            var projectList = _fileHandler.ReadProductsFromFile();
            int nextId = projectList.Any() ? projectList.Max(p => p.ID) + 1 : 1;
            project.ID = nextId;
            projectList.Add(project);
            _fileHandler.WriteProductsToFile(projectList);

            return Ok();
        }
        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            var projectList = _fileHandler.ReadProductsFromFile();
            var project = projectList.Find(p => p.ID == ID);
            if (project == null) return NotFound();
            projectList.Remove(project);
            _fileHandler.WriteProductsToFile(projectList);
            return Ok();
        }
    }
}
