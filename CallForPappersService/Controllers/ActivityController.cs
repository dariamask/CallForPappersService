using CallForPappersService.Data;
using CallForPappersService.Data.Entities;
using CallForPappersService.Data.Dto;
using Microsoft.AspNetCore.Mvc;
using CallForPappersService.Services;

namespace CallForPappersService.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<List<ActivityDto>>> GetActivitiesAsync()
        {
            return await _activityService.GetActivitiesAsync();
        }
    }
}
