using DotNetReact_BackEnd.Data;
using DotNetReact_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetReact_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleReactController : ControllerBase
    {
        // Serving the place of a database.
        private readonly DatabaseContext _context;


        public ExampleReactController(DatabaseContext context)
        {
            _context = context;
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

            if (_context.Strings.Any(x => x.String == newString.Trim())) return BadRequest("Data already present.");

            // For List:
            //if (Data.Contains(newString.Trim())) return BadRequest("Data already present.");
            // Step 4 - Business rules (none). (B)

            // Add the data.
            _context.Strings.Add(new Strings() { String = newString.Trim() });
            _context.SaveChanges();

            // For List:
            //Data.Add(newString.Trim());

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

            if (!_context.Strings.Any(x => x.String == oldString.Trim())) return NotFound("Target could not be found.");
            if (_context.Strings.Any(x => x.String == newString.Trim())) return BadRequest("Data already present.");

            // For List:
            //if (!Data.Contains(oldString.Trim())) return NotFound("Target could not be found.");
            //if (Data.Contains(newString.Trim())) return BadRequest("Update data already present.");
            // Business Rules (N/A)

            // Do the update.
            _context.Strings.Where(x => x.String == oldString.Trim()).Single().String = newString.Trim();
            _context.SaveChanges();

            // For List:
            //Data[Data.FindIndex(x => x == oldString)] = newString.Trim();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(string oldString)
        {
            // Null
            if (string.IsNullOrWhiteSpace(oldString)) return BadRequest("No target data provided.");
            // Format (N/A)
            // Presence
            if (!_context.Strings.Any(x => x.String == oldString.Trim())) return NotFound("Target could not be found.");

            // For List:
            //if (!Data.Contains(oldString.Trim())) return NotFound("Target could not be found.");
            // Business Rules (N/A)

            // Do the delete.
            _context.Remove(_context.Strings.Where(x => x.String == oldString.Trim()).Single());
            _context.SaveChanges();

            // For List:
            //Data.Remove(oldString.Trim());
            return Ok();
        }

        [HttpGet]
        [Route("list")]
        public IEnumerable<string> Read()
        {
            // We are using Select so we get a List<string> (primitive data type) and not a List<Strings> (our model).
            return _context.Strings.Select(x => x.String).ToList();
        }

        [HttpGet]
        [Route("count")]
        public int Count()
        {
            return _context.Strings.Count();
        }
    }
}
