using System.ComponentModel.DataAnnotations;

namespace CallForPappersService.Models
{
    public class Application
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        [Required]
        [StringLength(1000)]
        public string Outline { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public int ActivityId { get; set; }

    }
}
