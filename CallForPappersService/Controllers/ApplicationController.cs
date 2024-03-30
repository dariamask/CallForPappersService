using CallForPappersService.Data.Dto;
using Microsoft.AspNetCore.Mvc;
using CallForPappersService.Services;
using System.Threading;

namespace CallForPappersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : Controller
    {
        private readonly IApplicationService _applicationService;    
        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("applications")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ApplicationDto>> Create([FromBody] ApplicationCreateDto applicationCreateDto, CancellationToken cancellationToken = default)
        {
            return await _applicationService.CreateApplicationAsync(applicationCreateDto, cancellationToken);
        }

        [HttpGet("{applicationId}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ApplicationDto>> GetApplication(Guid applicationId)
        {
            return await _applicationService.GetApplicationAsync(applicationId);
        }

    }
}
