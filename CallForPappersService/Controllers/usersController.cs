using CallForPappersService_BAL.Dto;
using CallForPappersService_BAL.Services;
using FluentResults.Extensions.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CallForPappersService_PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : Controller
    {
        private readonly IApplicationService _applicationService;
        public usersController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("{userId}/currentapplication")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ApplicationDto>> GetUnsubmittedApplication(Guid userId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.GetUnsubmittedApplicationAsync(userId, cancellationToken);

            return result.ToActionResult();
        }
    }
}
