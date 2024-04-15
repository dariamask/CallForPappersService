using Microsoft.AspNetCore.Mvc;
using CallForPappersService_BAL.Services;
using CallForPappersService_BAL.Dto;
using FluentResults.Extensions.AspNetCore;

namespace CallForPappersService_PL.Controllers
{
    [Route("activities")]
    [ApiController]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<ActivityDto>>> GetActivitiesAsync(CancellationToken cancellationToken)
        {
            var result = await _activityService.GetActivitiesAsync(cancellationToken);
            return result.ToActionResult();
        }
    }
}
