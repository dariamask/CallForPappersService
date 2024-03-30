
using AutoMapper;
using CallForPappersService.Data.Entities;
using CallForPappersService.Data.Dto;
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

        [HttpPost("applications")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ApplicationDto>> Create([FromBody] ApplicationCreateDto applicationCreateDto, CancellationToken cancellationToken = default)
        {
            return await _applicationService.CreateApplicationAsync(applicationCreateDto, cancellationToken);
        }



    }
}
