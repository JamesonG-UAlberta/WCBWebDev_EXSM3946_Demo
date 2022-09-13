﻿using Microsoft.AspNetCore.Mvc;

namespace DotNetReact_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleReactController : ControllerBase
    {
        private static List<string> Data = new List<string>() { "Testing", "123" };

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Data;
        }
    }
}
