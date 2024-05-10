using CallForPappersService_DAL.Data.Entities;

namespace CallForPappersService_BAL.Dto
{
    public record ApplicationCreateDto
    {
        public string? Name { get; set; } 
        public string? Description { get; set; }

        public string? Outline { get; set; }

        public ActivityType ActvityTypeName { get; set; }

        public Guid AuthorId { get; set; }        
    }
}
