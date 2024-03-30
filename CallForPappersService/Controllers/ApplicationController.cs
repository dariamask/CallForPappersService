
using AutoMapper;
using CallForPappersService.Data.Entities;
using CallForPappersService.Dto;
using CallForPappersService.Interfaces;
using CallForPappersService.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CallForPappersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : Controller
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IAuthorRepository _authorRepository;       
        public ApplicationController(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        [HttpGet("{applicationId}")]
        [ProducesResponseType(200)]
        public IActionResult GetApplicationByAuthorId(Guid applicationId)
        {
            var applications = _applicationRepository.GetApplication(applicationId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(applications);
        }

        [HttpGet]
        [Route("/applications/{submittedAfter}")]
        public IActionResult GetSumbittetApplicationsByDate(DateTime submittedAfter)
        {
            var applications = _applicationRepository.GetApplicationsByDate(submittedAfter);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(applications);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateApplication([FromBody] CreateApplicationDto applicationCreate)
        {
            if (applicationCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var application = new Application
            {
                AuthorId = (Guid)applicationCreate.AuthorId,
                Name = applicationCreate.Name,
                Description = applicationCreate.Description,
                Outline = applicationCreate.Outline,
                CreatedDate = DateTime.Now,
                //Status = (Status.Pending).ToString(),
                Activity = new Activity
                {
                    //ActivityType = applicationCreate.ActvityTypeName,
                    Description = "доклад"
                }
            };

            int x = 5;

            _applicationRepository.CreateApplication(application);


            //if (!_applicationRepository.CreateApplication(application))
            //{
            //    ModelState.AddModelError("", "Something went wrong while savin");
            //    return StatusCode(500, ModelState);
            //}

            return Ok("Successfully created");
        }



    }
}
