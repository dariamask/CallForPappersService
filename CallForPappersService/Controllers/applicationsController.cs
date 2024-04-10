using Microsoft.AspNetCore.Mvc;
using CallForPappersService_BAL.Services;
using CallForPappersService_BAL.Dto;
using FluentResults.Extensions.AspNetCore;
using Microsoft.Net.Http.Headers;
using FluentResults;

namespace CallForPappersService_PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class applicationsController : Controller
    {
        private readonly IApplicationService _applicationService;
        public applicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ApplicationDto>> Create([FromBody] ApplicationCreateDto applicationCreateDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _applicationService.CreateApplicationAsync(applicationCreateDto, cancellationToken);

            return result.ToActionResult();
        }


        [HttpGet("{applicationId}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ApplicationDto>> GetApplication(Guid applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.GetApplicationAsync(applicationId, cancellationToken);

            return result.ToActionResult();
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<ApplicationDto>>> GetApplication(
            [FromQuery] DateTime? submittedAfter, 
            [FromQuery] DateTime? unsubmittedOlder, 
            CancellationToken cancellationToken)
        {
            Result<List<ApplicationDto>> result = (submittedAfter, unsubmittedOlder) switch
            {
                (null, { } submittedOlder) => await _applicationService.GetUnsubmittedApplicationOlderDateAsync(unsubmittedOlder, cancellationToken),
                ({ } sumittedAfter, null) => await _applicationService.GetApplicationsSubmittedAfterDateAsync(submittedAfter, cancellationToken),
                ({ } sumittedAfter, { } submittedOlder) => new Error ("Only one parametr must be filled in"),
                _ => new Error("One field must be filled in")
            };

            return result.ToActionResult();
        }

        [HttpPut("{applicationId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ApplicationDto>> UpdateApplication(Guid applicationId, 
            [FromBody] ApplicationUpdateDto applicationUpdateDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _applicationService.UpdateApplicationAsync(applicationId, applicationUpdateDto, cancellationToken);
            
            return result.ToActionResult();
        }

        [HttpPost("{applicationId}/submit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> SubmitApplication(Guid applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.SubmitApplicationAsync(applicationId, cancellationToken);

            return result.ToActionResult();
        }

        [HttpDelete("{applicationId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteApplication(Guid applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.DeleteAplicationAsync(applicationId, cancellationToken);

            return result.ToActionResult();
        }
    }
}
