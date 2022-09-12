using Microsoft.AspNetCore.Mvc;

namespace DotNetReact_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleReactController : ControllerBase
    {
        private static List<string> Data = new List<string>();

        private readonly ILogger<ExampleReactController> _logger;

        public ExampleReactController(ILogger<ExampleReactController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public ActionResult Create(string newString)
        {
            if (string.IsNullOrWhiteSpace(newString)) return BadRequest("No data provided.");
            if (Data.Contains(newString.Trim())) return BadRequest("Data already present.");
            Data.Add(newString.Trim());
            return Ok();
        }

        [HttpPatch]
        public ActionResult Update(string oldString, string newString)
        {
            if (string.IsNullOrWhiteSpace(oldString)) return BadRequest("No target data provided.");
            if (string.IsNullOrWhiteSpace(newString)) return BadRequest("No update data provided.");
            if (!Data.Contains(oldString.Trim())) return NotFound("Target could not be found.");
            if (Data.Contains(newString.Trim())) return BadRequest("Update data already present.");
            Data[Data.FindIndex(x => x == oldString)] = newString.Trim();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(string oldString)
        {
            if (string.IsNullOrWhiteSpace(oldString)) return BadRequest("No target data provided.");
            if (!Data.Contains(oldString.Trim())) return NotFound("Target could not be found.");
            Data.Remove(oldString.Trim());
            return Ok();
        }

        [HttpGet]
        public IEnumerable<string> Read()
        {
            return Data;
        }
    }
}
