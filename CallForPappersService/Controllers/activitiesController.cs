using Microsoft.AspNetCore.Mvc;
using CallForPappersService_BAL.Services;
using CallForPappersService_BAL.Dto;

namespace CallForPappersService_PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class activitiesController : Controller
    {
        private readonly IActivityService _activityService;
        public activitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<ActivityDto>>> GetActivitiesAsync()
        {
            var activities = await _activityService.GetActivitiesAsync();
            return Ok(activities);
        }
    }
}
