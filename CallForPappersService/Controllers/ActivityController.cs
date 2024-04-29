using Microsoft.AspNetCore.Mvc;
using CallForPappersService_BAL.Services;
using CallForPappersService_BAL.Dto;
using FluentResults.Extensions.AspNetCore;
using Serilog;

namespace CallForPappersService_PL.Controllers
{
    [Route("activities")]
    [ApiController]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        private readonly ILogger<ActivityController> _logger;
        public ActivityController(
            IActivityService activityService, 
            ILogger<ActivityController> logger)
        {
            _activityService = activityService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<ActivityDto>>> GetActivitiesAsync(CancellationToken cancellationToken)
        {
            //loggerTesting
            _logger.LogCritical("Oh my God, they killed Kenny!");
            _logger.LogWarning("You bastards!");
            var result = await _activityService.GetActivitiesAsync(cancellationToken);
            return result.ToActionResult();
        }
    }
}
