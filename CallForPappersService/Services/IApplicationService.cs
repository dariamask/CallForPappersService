using CallForPappersService.Data.Dto;

namespace CallForPappersService.Services
{
    public interface IApplicationServices
    {
        public Task<ApplicationDto> CreateApplicationAsync(ApplicationCreateDto dto, CancellationToken cancellationToken);
    }
}
