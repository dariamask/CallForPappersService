using CallForPappersService.Data;
using CallForPappersService.Data.Entities;
using CallForPappersService.Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CallForPappersService.Repository;

namespace CallForPappersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : Controller
    {
        private readonly IActivityRepository _activityRepository;
        private readonly DataContext _context;
        public ActivityController(IActivityRepository activityRepository, DataContext context)
        {
            _activityRepository = activityRepository;
            _context = context;
        }

        [HttpPost("activities")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ActivityDto>> Create([FromBody] ApplicationCreateDto applicationCreateDto, CancellationToken cancellationToken = default)
        {
            return await _applicationService.CreateApplicationAsync(applicationCreateDto, cancellationToken);
        }

    }
}
