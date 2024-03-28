using System.ComponentModel.DataAnnotations;

namespace CallForPappersService.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        ICollection<ApplicationModel> Applications { get; set; }
    }
}
