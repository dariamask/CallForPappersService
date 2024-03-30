using CallForPappersService.Data;
using CallForPappersService.Data.Entities;
using CallForPappersService.Data.Dto;
using CallForPappersService.Models;
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateActivity([FromBody] CreateActivityDto activityCreate)
        {
            if (activityCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var activity = new Activity
            //{
            //    Id = activityCreate.Id,
            //    ActivityType = activityCreate.ActivityType,
            //    Description = activityCreate.Description,
            //};

            //_context.Add(activity);
            //_context.SaveChanges();

            //author: "ddfea950-d878-4bfe-a5d7-e9771e830cbd",
            //type: "Report",
            //name: "Новые фичи C# vNext",
            //description: "Расскажу что нас ждет в новом релизе!",
            //outline: "очень много текста... прямо детальный план доклада!",

            //if (!_applicationRepository.CreateApplication(application))
            //{
            //    ModelState.AddModelError("", "Something went wrong while savin");
            //    return StatusCode(500, ModelState);
            //}

            return Ok("Successfully created");
        }
    }
}
