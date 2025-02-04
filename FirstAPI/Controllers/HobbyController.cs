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
            var products = _fileHandler.ReadProductsFromFile();

            products.Add(hobby);
            _fileHandler.WriteProductsToFile(products);

            return Ok();
        }
    }
}
