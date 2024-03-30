using CallForPappersService.Data.Dto;
using CallForPappersService.Data.Entities;

namespace CallForPappersService.Services
{
    public class ApplicationServices : IApplicationServices
    {
        public Task<ApplicationDto> CreateApplicationAsync(ApplicationCreateDto dto, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(dto);

            var application = new Application
            {
                AuthorId = dto.AuthorId,
                Name = dto.Name!,
                Description = dto.Description!,
                Outline = dto.Outline!,
                CreatedDate = DateTime.Now,
                Status = ApplicationStatus.Pending
            };

           
        }
    }
}
