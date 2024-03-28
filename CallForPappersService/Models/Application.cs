using System.ComponentModel.DataAnnotations;

namespace CallForPappersService.Models
{
    public class Application
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Outline { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public Author Author { get; set; }
        public ActivityType Activity { get; set; }

    }
}
