using CallForPappersService.Data.Dto;
using Microsoft.AspNetCore.Mvc;
using CallForPappersService.Services;
using System.Threading;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CallForPappersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : Controller
    {
        private readonly IApplicationService _applicationService;
        private readonly IValidator<ApplicationCreateDto> _validatorCreate;
        private readonly IValidator<ApplicationUpdateDto> _validatorUpdate;
        public ApplicationController(IApplicationService applicationService, 
                                     IValidator<ApplicationCreateDto> validatorCreate,
                                     IValidator<ApplicationUpdateDto> validatorUpdate)
        {
            _applicationService = applicationService;
            _validatorCreate = validatorCreate;
            _validatorUpdate = validatorUpdate;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ApplicationDto>> Create([FromBody] ApplicationCreateDto applicationCreateDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validatorCreate.ValidateAsync(applicationCreateDto);

            if (!validationResult.IsValid)
            {
                var modelStateDictionary = new ModelStateDictionary();

                validationResult.Errors
                    .ForEach(failure => modelStateDictionary
                    .AddModelError(failure.PropertyName, failure.ErrorMessage));

                return ValidationProblem(modelStateDictionary);
            }

            var application = await _applicationService.CreateApplicationAsync(applicationCreateDto, cancellationToken);
            return application == null ? BadRequest("Something went wrong") : Ok(application);
        }


        [HttpGet("{applicationId}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ApplicationDto>> GetApplication(Guid applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.GetApplicationAsync(applicationId, cancellationToken);

            if(! result.IsSuccess)
            {
                return BadRequest(result.Error.Description);
            }

            return Ok(result.Value);
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


        [HttpGet("~/users/{applicationId}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ApplicationDto>> GetUnsubmittedApplication(Guid applicationId, CancellationToken cancellationToken)
        {          
            var dto = await _applicationService.GetUnsubmittedApplicationAsync(applicationId, cancellationToken);

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
        public async Task<ActionResult<ApplicationDto>> UpdateApplication(Guid applicationId, 
            [FromBody] ApplicationUpdateDto applicationUpdateDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validatorUpdate.ValidateAsync(applicationUpdateDto);

            if (!validationResult.IsValid)
            {
                var modelStateDictionary = new ModelStateDictionary();

                validationResult.Errors
                    .ForEach(x => modelStateDictionary
                    .AddModelError(x.PropertyName, x.ErrorMessage));
            }

            var application = await _applicationService.UpdateApplicationAsync(applicationId, applicationUpdateDto, cancellationToken);
            return application == null ? BadRequest("Something went wrong") : Ok(application);
        }

        [HttpPost("{applicationId}/submit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> SubmitApplication(Guid applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.SubmitApplicationAsync(applicationId, cancellationToken);
            return result ? Ok("Success") : BadRequest("Something went wrong with submitting");
        }

        [HttpDelete("{applicationId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteApplication(Guid applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.DeleteAplicationAsync(applicationId, cancellationToken);
            return result ? Ok("Success") : BadRequest("Something went wrong");         
        }
    }
}
