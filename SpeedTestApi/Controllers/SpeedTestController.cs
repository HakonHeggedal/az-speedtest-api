using System;
using Microsoft.AspNetCore.Mvc;
using  SpeedTestApi.Models;
using Microsoft.Extensions.Logging;

namespace SpeedTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeedTestController : ControllerBase
    {

        private readonly ILogger _logger;

        public SpeedTestController(ILogger<SpeedTestController> logger)
        {
            _logger = logger;
        }

        [Route("ping")]
        [HttpGet]
        public string Ping()
        {
            return "PONG";
        }

        [HttpPost]
        public string UploadSpeedTest([FromBody] TestResult speedTest)
        {
            var response = $"Got a TestResult from { speedTest.User } with download { speedTest.Data.Speeds.Download } Mbps.";
            _logger.LogInformation(response);

            return response;
        }

    }
}
