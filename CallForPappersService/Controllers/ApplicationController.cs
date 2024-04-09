using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using CallForPappersService_BAL.Services;
using CallForPappersService_BAL.Dto;
using FluentResults;

namespace CallForPappersService_PL.Controllers
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
        public async Task<ActionResult<ApplicationDto>> Create([FromBody] ApplicationCreateDto applicationCreateDto, CancellationToken cancellationToken)
        {
            var result = await _applicationService.CreateApplicationAsync(applicationCreateDto, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
        }


        [HttpGet("{applicationId}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ApplicationDto>> GetApplication(Guid applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.GetApplicationAsync(applicationId, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<ApplicationDto>>> GetApplication([FromQuery] DateTime? submittedAfter, [FromQuery] DateTime? unsubmittedOlder, CancellationToken cancellationToken)
        {
            if (unsubmittedOlder == null && submittedAfter != null)
            {
                return await _applicationService.GetApplicationsSubmittedAfterDateAsync(submittedAfter, cancellationToken);
            }
            else if (submittedAfter == null && unsubmittedOlder != null)
            {
                return await _applicationService.GetUnsubmittedApplicationOlderDateAsync(unsubmittedOlder, cancellationToken);
            }
            else
            {
                return BadRequest("Invalid combination of parametrs");
            }
        }


        [HttpGet("~/users/{userId}/currentapplication")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ApplicationDto>> GetUnsubmittedApplication(Guid userId, CancellationToken cancellationToken)
        {          
            var result = await _applicationService.GetUnsubmittedApplicationAsync(userId, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors[0]);
        }

        [HttpPut("{applicationId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ApplicationDto>> UpdateApplication(Guid applicationId, 
            [FromBody] ApplicationUpdateDto applicationUpdateDto, CancellationToken cancellationToken)
        {
            //var validationResult = await _validatorUpdate.ValidateAsync(applicationUpdateDto);

            //if (!validationResult.IsValid)
            //{
            //    var modelStateDictionary = new ModelStateDictionary();

            //    validationResult.Errors
            //        .ForEach(x => modelStateDictionary
            //        .AddModelError(x.PropertyName, x.ErrorMessage));
            //}

            var application = await _applicationService.UpdateApplicationAsync(applicationId, applicationUpdateDto, cancellationToken);
            return application == null ? BadRequest("Something went wrong") : Ok(application);
        }

        [HttpPost("{applicationId}/submit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> SubmitApplication(Guid applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.SubmitApplicationAsync(applicationId, cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest(result.Errors);
        }

        [HttpDelete("{applicationId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteApplication(Guid applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.DeleteAplicationAsync(applicationId, cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest(result.Errors);
        }
    }
}
