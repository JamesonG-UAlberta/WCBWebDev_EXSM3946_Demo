using Microsoft.AspNetCore.Mvc;

namespace DotNetReact_BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InClassController : ControllerBase
    {

        private static List<int> Data = new List<int>();

        private readonly ILogger<InClassController> _logger;

        public InClassController(ILogger<InClassController> logger)
        {
            _logger = logger;
        }

        // -- TASKS --
        // Copy and paste anything necessary from ExampleReactController.
        // Implement a similar setup thereto, but storing integers instead of strings.
        // As part of the validation (add to existing validation), ensure any values are valid integers.
        // Add an additional get endpoint that will return a sum of all the integers in the list.


        [HttpPost]
        public ActionResult Create(string newInt)
        {
            // 1. Check to see if the argument exists at all (not null).
            if (string.IsNullOrWhiteSpace(newInt)) return BadRequest("No data provided.");
            // 2. Check to see if the data is in the correct format (is an int).
            int convertedInt;
            if (!int.TryParse(newInt, out convertedInt)) return BadRequest("Please ensure the data is an integer.");
            /* Try / Catch Method:
            try
            {
                convertedInt = int.Parse(newInt.Trim());
            }
            catch
            {
                return BadRequest("Please ensure the data is an integer.");
            }
            */
            // 3. Check to see if the list already contains the data.
            if (Data.Contains(convertedInt)) return BadRequest("Data already present.");
            // 4. If applicable, check against business rules (multi-field after all single-field validation is performed)
            Data.Add(convertedInt);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(string oldInt, string newInt)
        {
        }

        [HttpDelete]
        public ActionResult Delete(string oldInt)
        {
        }

        [HttpGet]
        [Route("list")] // localhost:7048/InClass/list (GET)
        public IEnumerable<int> Read()
        {
            return Data;
        }

        [HttpGet]
        [Route("sum")] // localhost:7048/InClass/sum (GET)
        public int Sum()
        {
            return 0;
        }
    }
}
