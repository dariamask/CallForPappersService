using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CallForPappersService.Models
{
    public class ApplicationModel
    {
        public Guid Id { get; set; }
        [Required][StringLength(100)]public string Name { get; set; }
        public string Description { get; set; }
        [Required]public string Outline { get; set; }
        public Guid AuthorId { get; set; }
        public string Activity { get; set; }
        public int ActivityId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }

    }
}
