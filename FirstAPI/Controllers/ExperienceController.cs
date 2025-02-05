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
        [HttpPost]
        public IActionResult Create([FromBody] Experience experience)
        {
            var ExperienceList = _fileHandler.ReadProductsFromFile();
            int nextId = ExperienceList.Any() ? ExperienceList.Max(p => p.ID) + 1 : 1;
            experience.ID = nextId;
            ExperienceList.Add(experience);
            _fileHandler.WriteProductsToFile(ExperienceList);

            return Ok();
        }
        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            var achivementsList = _fileHandler.ReadProductsFromFile();
            var hobby = achivementsList.Find(p => p.ID == ID);
            if (hobby == null) return NotFound();
            achivementsList.Remove(hobby);
            _fileHandler.WriteProductsToFile(achivementsList);
            return Ok();
        }
    }
}
