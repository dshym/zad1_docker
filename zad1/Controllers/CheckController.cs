using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace zad1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckController : ControllerBase
    {

        private readonly ILogger<CheckController> _logger;

        public CheckController(ILogger<CheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = new ResultInfo();
            result.IP = "0.0.0.1";
            result.Time = DateTime.Now;
            return Ok(result);

        }

        public class ResultInfo
        {
            public string IP { get; set; }

            public DateTime Time { get; set; }
        }
    }
}
