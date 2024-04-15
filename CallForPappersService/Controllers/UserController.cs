using CallForPappersService_BAL.Dto;
using CallForPappersService_BAL.Services;
using FluentResults.Extensions.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace CallForPappersService_PL.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IApplicationService _applicationService;
        public UserController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("{userId}/currentapplication")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ApplicationDto>> GetUnsubmittedApplication(Guid userId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.GetUnsubmittedApplicationAsync(userId, cancellationToken);

            return result.ToActionResult();
        }
    }
}
