using System.Text.Json;
using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("/user")] //set route
    [ApiController] // Bring in apicontroller
    public class UserController:ControllerBase //1 inherit controllerbase
    {
        private readonly string _filePath = "Data/data.json";

        // Read JSON file and deserialize it
        private List<User> ReadProductsFromFile()
        {
            if (!System.IO.File.Exists(_filePath)) return new List<User>();

            var jsonData = System.IO.File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<User>>(jsonData) ?? new List<User>();
        }

        // Write to JSON file
        private void WriteProductsToFile(List<User> products)
        {
            var jsonData = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_filePath, jsonData);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ReadProductsFromFile());
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            var products = ReadProductsFromFile();

            products.Add(user);
            WriteProductsToFile(products);

            return Ok();
        }
    }
}
