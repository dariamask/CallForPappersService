
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateApplication([FromBody] CreateApplicationDto applicationCreate)
        {
            if (applicationCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var application = new ApplicationModel
            {
                AuthorId = (Guid)applicationCreate.AuthorId,
                Name = applicationCreate.Name,
                Description = applicationCreate.Description,
                Outline = applicationCreate.Outline,
                CreatedDate = DateTime.Now,
                Status = "Unsubmitted", 
                Activity = applicationCreate.ActvityTypeName,    
            };

            int x = 5;
            //if (!_applicationRepository.CreateApplication(application))
            //{
            //    ModelState.AddModelError("", "Something went wrong while savin");
            //    return StatusCode(500, ModelState);
            //}

            return Ok("Successfully created");
        }



    }
}
