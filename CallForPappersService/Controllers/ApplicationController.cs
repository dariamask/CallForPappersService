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

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ApplicationDto>> Create([FromBody] ApplicationCreateDto applicationCreateDto, CancellationToken cancellationToken = default)
        {
            var application = await _applicationService.CreateApplicationAsync(applicationCreateDto, cancellationToken);
            return application == null ? BadRequest("Something went wrong") : Ok(application);
        }


        [HttpGet("{applicationId}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ApplicationDto>> GetApplication(Guid applicationId)
        {
            return await _applicationService.GetApplicationAsync(applicationId);
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<ApplicationDto>>> GetApplication([FromQuery] DateTime? submittedAfter, [FromQuery] DateTime? unsubmittedOlder)
        {
            if (unsubmittedOlder == null && submittedAfter != null)
            {
                return await _applicationService.GetApplicationsSubmittedAfterDateAsync(submittedAfter);
            }
            else if (submittedAfter == null && unsubmittedOlder != null)
            {
                return await _applicationService.GetUnsubmittedApplicationOlderDateAsync(unsubmittedOlder);
            }
            else
            {
                return BadRequest("Invalid combination of parametrs");
            }
        }


        [HttpGet("users/{applicationId}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ApplicationDto>> GetUnsubmittedApplication(Guid applicationId)
        {          
            var dto = await _applicationService.GetUnsubmittedApplicationAsync(applicationId);

            if (dto == null)
            {
                return BadRequest("Application status is active or it doesn't exists");
            }

            return Ok(dto);
        }

        [HttpPut("{applicationId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ApplicationDto>> UpdateApplication(Guid applicationId, [FromBody] ApplicationUpdateDto updatedApplication)
        {            
            var application = await _applicationService.UpdateApplicationAsync(applicationId, updatedApplication);
            return application == null ? BadRequest("Something went wrong") : Ok(application);
        }

        [HttpPost("{applicationId}/submit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> SubmitApplication(Guid applicationId)
        {
            var result = await _applicationService.SubmitApplicationAsync(applicationId);
            return result ? Ok("Success") : BadRequest("Something went wrong with submitting");
        }

        [HttpDelete("{applicationId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteApplication(Guid applicationId)
        {
            var result = await _applicationService.DeleteAplicationAsync(applicationId);
            return result ? Ok("Success") : BadRequest("Something went wrong");         
        }
    }
}
