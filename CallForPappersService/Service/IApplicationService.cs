using CallForPappersService.Data.Dto;

namespace CallForPappersService.Service
{
    public interface IApplicationService
    {
        public Task<ApplicationDto> CreateApplicationAsync(ApplicationCreateDto dto, CancellationToken cancellationToken);
    }
}
