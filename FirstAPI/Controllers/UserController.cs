using System.Text.Json;
using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("[controller]")] //set route
    [ApiController] // Bring in apicontroller
    public class UserController:ControllerBase //1 inherit controllerbase
    {
        private readonly FileHandler<User> _fileHandler;
        private readonly string filepath = "Data/data.json";
        public UserController()
        {
            _fileHandler = new FileHandler<User>(filepath);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_fileHandler.ReadProductsFromFile());
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            var products = _fileHandler.ReadProductsFromFile();

            products.Add(user);
            _fileHandler.WriteProductsToFile(products);

            return Ok();
        }
    }
}
