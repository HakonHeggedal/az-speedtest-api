using System;
using Microsoft.AspNetCore.Mvc;
using  SpeedTestApi.Models;
using Microsoft.Extensions.Logging;
using SpeedTestApi.Services;
using System.Threading.Tasks;

namespace SpeedTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeedTestController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly ISpeedTestEvents _eventHub;

        public SpeedTestController(ILogger<SpeedTestController> logger, ISpeedTestEvents eventHub)
        {
            _logger = logger;
            _eventHub = eventHub;
        }

        [Route("ping")]
        [HttpGet]
        public string Ping()
        {
            return "PONG";
        }

        [HttpPost]
        public async Task<string> UploadSpeedTest([FromBody] TestResult speedTest)
        {
            await _eventHub.PublishSpeedTest(speedTest);

            var response = $"Got a TestResult from { speedTest.User } with download { speedTest.Data.Speeds.Download } Mbps.";
            _logger.LogInformation(response);

            return response;
        }

    }
}
