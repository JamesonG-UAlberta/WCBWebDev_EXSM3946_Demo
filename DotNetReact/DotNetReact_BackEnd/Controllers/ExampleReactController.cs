using Microsoft.AspNetCore.Mvc;

namespace DotNetReact_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleReactController : ControllerBase
    {
        // Serving the place of a database.
        private static List<string> Data = new List<string>();

        private readonly ILogger<ExampleReactController> _logger;

        public ExampleReactController(ILogger<ExampleReactController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public ActionResult Create(string newString)
        {
            // Null - Format - Presence - BusinessRules
            // Never Forget Peanut Butter

            // Step 1 - Data is present. (N)
            if (string.IsNullOrWhiteSpace(newString)) return BadRequest("No data provided.");
            // Step 2 - Data is in the correct format (not applicable for strings). (F)
            // Step 3 - Data is or is not present in the database already. (P)
            if (Data.Contains(newString.Trim())) return BadRequest("Data already present.");
            // Step 4 - Business rules (none). (B)

            // Add the data.
            Data.Add(newString.Trim());
            return Ok();
        }

        [HttpPatch]
        public ActionResult Update(string oldString, string newString)
        {
            // Null
            if (string.IsNullOrWhiteSpace(oldString)) return BadRequest("No target data provided.");
            if (string.IsNullOrWhiteSpace(newString)) return BadRequest("No update data provided.");
            // Format (N/A)
            // Presence
            if (!Data.Contains(oldString.Trim())) return NotFound("Target could not be found.");
            if (Data.Contains(newString.Trim())) return BadRequest("Update data already present.");
            // Business Rules (N/A)

            // Do the update.
            Data[Data.FindIndex(x => x == oldString)] = newString.Trim();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(string oldString)
        {
            // Null
            if (string.IsNullOrWhiteSpace(oldString)) return BadRequest("No target data provided.");
            // Format (N/A)
            // Presence
            if (!Data.Contains(oldString.Trim())) return NotFound("Target could not be found.");
            // Business Rules (N/A)

            // Do the delete.
            Data.Remove(oldString.Trim());
            return Ok();
        }

        [HttpGet]
        [Route("list")]
        public IEnumerable<string> Read()
        {
            return Data;
        }

        [HttpGet]
        [Route("count")]
        public int Count()
        {
            return Data.Count;
        }
    }
}
