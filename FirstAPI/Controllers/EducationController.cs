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
        [HttpGet("{id}")]
        public IActionResult GetByID(int id) {
            var EducationList = _fileHandler.ReadProductsFromFile();
            var education = EducationList.Find(p => p.ID == id);
            if (education == null) return NotFound();
            return Ok(education);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Education education)
        {
            var EducationList = _fileHandler.ReadProductsFromFile();
            int nextId = EducationList.Any() ? EducationList.Max(p => p.ID) + 1 : 1;
            education.ID = nextId;
            EducationList.Add(education);
            _fileHandler.WriteProductsToFile(EducationList);

            return Ok();
        }
        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            var EducationList = _fileHandler.ReadProductsFromFile();
            var education = EducationList.Find(p => p.ID == ID);
            if (education == null) return NotFound();
            EducationList.Remove(education);
            _fileHandler.WriteProductsToFile(EducationList);
            return Ok();
        }
    }
}
