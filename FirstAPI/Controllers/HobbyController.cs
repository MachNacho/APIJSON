using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("[controller]")] // Set route
    [ApiController] // Bring in apicontroller
    public class HobbyController : ControllerBase
    {
        private readonly FileHandler<Hobby> _fileHandler;
        private readonly string filepath = "Data/JSON/Hobby.json";
        public HobbyController()
        {
            _fileHandler = new FileHandler<Hobby>(filepath);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_fileHandler.ReadProductsFromFile());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Hobby hobby)
        {
            var hob = _fileHandler.ReadProductsFromFile();
            int nextId = hob.Any() ? hob.Max(p => p.ID) + 1 : 1;
            hobby.ID = nextId;
            hob.Add(hobby);
            _fileHandler.WriteProductsToFile(hob);

            return Ok();
        }
        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            var hob = _fileHandler.ReadProductsFromFile();
            var hobby = hob.Find(p => p.ID == ID);
            if (hobby == null) return NotFound();
            hob.Remove(hobby);
            _fileHandler.WriteProductsToFile(hob);
            return Ok();
        }
    }
}
