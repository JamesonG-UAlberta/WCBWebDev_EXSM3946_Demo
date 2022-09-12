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
        public void Post()
        {
        }

        [HttpPut]
        public void Put()
        {
        }

        [HttpDelete]
        public void Delete()
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
