using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AccessJson.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<EntityAttributeValue>> Get()
        {
            try
            {
                // Read data from JSON file
                string jsonFilePath = "data.json";
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);

                // Deserialize JSON to list of EntityAttributeValue objects
                var entities = JsonSerializer.Deserialize<List<EntityAttributeValue>>(jsonData);

                // Return the deserialized data
                return Ok(entities);
            }
            catch (System.Exception ex)
            {
                // Return internal server error if an exception occurs
                return StatusCode(500, new { error = "Internal Server Error" });
            }
        }
    }
}
