using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SpeedTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeedTestController : ControllerBase
    {

        [Route("ping")]
        [HttpGet]
        public string Ping()
        {
            return "PONG";
        }

    }
}
