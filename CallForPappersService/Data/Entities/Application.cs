using System.ComponentModel.DataAnnotations;

namespace CallForPappersService.Data.Entities
{
    public class Application
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Outline { get; set; }
        public DateTime CreatedDate { get; set; }
        public ApplicationStatus Status { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
    public enum ApplicationStatus
    {
        Pending = 0,
        Active = 1,
    }
}
