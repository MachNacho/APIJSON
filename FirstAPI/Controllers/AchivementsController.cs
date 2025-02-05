using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AchivementsController : ControllerBase
    {
        private readonly FileHandler<Achivement> _fileHandler;
        private readonly string filepath = "Data/JSON/Achivements.json";
        public AchivementsController()
        {
            _fileHandler = new FileHandler<Achivement>(filepath);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_fileHandler.ReadProductsFromFile());
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id) {
            var achivementsList = _fileHandler.ReadProductsFromFile();
            var achivement = achivementsList.Find(p => p.ID == id);
            if (achivement == null) return NotFound();
            return Ok(achivement);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Achivement Ach)
        {
            var achivementsList = _fileHandler.ReadProductsFromFile();
            int nextId = achivementsList.Any() ? achivementsList.Max(p => p.ID) + 1 : 1;
            Ach.ID = nextId;
            achivementsList.Add(Ach);
            _fileHandler.WriteProductsToFile(achivementsList);

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
