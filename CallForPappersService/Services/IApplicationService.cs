using CallForPappersService.Data.Dto;

namespace CallForPappersService.Services
{
    public interface IApplicationService
    {
        public Task<ApplicationDto> CreateApplicationAsync(ApplicationCreateDto dto, CancellationToken cancellationToken);
    }
}
