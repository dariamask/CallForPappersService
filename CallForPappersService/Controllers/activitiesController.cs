using Microsoft.AspNetCore.Mvc;
using CallForPappersService_BAL.Services;
using CallForPappersService_BAL.Dto;
using FluentResults.Extensions.AspNetCore;

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
        public async Task<ActionResult<List<ActivityDto>>> GetActivitiesAsync(CancellationToken cancellationToken)
        {
            var result = await _activityService.GetActivitiesAsync(cancellationToken);
            return result.ToActionResult();
        }
    }
}
