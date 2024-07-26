using System.Text.Json;
using api.Entity;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly ILogger<HelloController> _logger;

        public HelloController(ILogger<HelloController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("GET request received at HelloController");
            List<Book> books = new HelloModel().GetAllBooks();
            string json = JsonSerializer.Serialize(books, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            _logger.LogInformation("Returning: " + json);
            return json;
        }

        [HttpPost]
        public string Post()
        {
            _logger.LogInformation("POST request received at HelloController");
            return "POST: Hello, World!";
        }

        [HttpPut]
        public string Put()
        {
            _logger.LogInformation("PUT request received at HelloController");
            return "PUT: Hello, World!";
        }

        [HttpDelete]
        public string Delete()
        {
            _logger.LogInformation("DELETE request received at HelloController");
            return "DELETE: Hello, World!";
        }
    }
}
