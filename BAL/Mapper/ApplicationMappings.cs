using CallForPappersService_BAL.Dto;
using CallForPappersService_DAL.Data.Entities;

namespace CallForPappersService_BAL.Mapper
{
    public static class ApplicationMappings
    {
        public static ApplicationDto MapToResponse(this Application application)
        {
            return new ApplicationDto
            {
                Id = application.Id,
                AuthorId = application.AuthorId,
                ActvityTypeName = application.ActivityType,
                Name = application.Name,
                Description = application.Description,
                Outline = application.Outline,
            };
        }
        public static List<ApplicationDto> MapToResponse(this IEnumerable<Application> applications) =>
           applications.Select(MapToResponse).ToList();
    }
}
