using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
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
    }
}
