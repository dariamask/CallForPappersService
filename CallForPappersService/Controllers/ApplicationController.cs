
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

            //var category = _applicationRepository.GetApplications()
            //    .Where(c => c.Name.Trim().ToUpper() == categoryCreate.Name.TrimEnd().ToUpper())
            //    .FirstOrDefault();

            //if (category != null)
            //{
            //    ModelState.AddModelError("", "Category already exists");
            //    return StatusCode(422, ModelState);
            //}

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var application = new Application
            {
                AuthorId = applicationCreate.AuthorId,
                Name = applicationCreate.Name,
                Description = applicationCreate.Description,
                Outline = applicationCreate.Outline,
                CreatedDate = DateTime.Now,
                Status = "Unsubmitted",
                ActivityId = 5
            };

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
