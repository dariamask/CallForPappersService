using Microsoft.AspNetCore.Mvc;
using CallForPappersService_BAL.Services;
using CallForPappersService_BAL.Dto;
using FluentResults.Extensions.AspNetCore;
using FluentResults;

namespace CallForPappersService_PL.Controllers
{
    [Route("applications")]
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
        public async Task<ActionResult<ApplicationDto>> Create([FromBody] ApplicationCreateDto request, CancellationToken cancellationToken)
        {
            var result = await _applicationService.CreateApplicationAsync(request, cancellationToken);

            return result.ToActionResult();
        }


        [HttpGet("{applicationId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ApplicationDto>> GetApplication(Guid applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.GetApplicationAsync(applicationId, cancellationToken);

            return result.ToActionResult();
        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<ApplicationDto>>> GetApplication(
            [FromQuery] ApplicationGetDto request,
            CancellationToken cancellationToken)
        {
            var result = request switch
            {
                { SubmittedAfter: not null} and { UnsubmittedOlder: not null} => new Error ("Only one parametr must be set"),
                { SubmittedAfter: not null } => await _applicationService.GetApplicationsSubmittedAfterDateAsync(request.SubmittedAfter, cancellationToken),
                { UnsubmittedOlder: not null} => await _applicationService.GetUnsubmittedApplicationOlderDateAsync(request.UnsubmittedOlder, cancellationToken),
                _ => new Error("One field must be set")
            };

            return result.ToActionResult();
        }

        [HttpPut("{applicationId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ApplicationDto>> UpdateApplication(Guid applicationId, 
            [FromBody] ApplicationUpdateDto request, CancellationToken cancellationToken)
        {
            var result = await _applicationService.UpdateApplicationAsync(applicationId, request, cancellationToken);
            
            return result.ToActionResult();
        }

        [HttpPost("{applicationId}/submit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> SubmitApplication(Guid applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.SubmitApplicationAsync(applicationId, cancellationToken);

            return result.ToActionResult();
        }

        [HttpDelete("{applicationId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> DeleteApplication(Guid applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.DeleteAplicationAsync(applicationId, cancellationToken);

            return result.ToActionResult();
        }
    }
}
