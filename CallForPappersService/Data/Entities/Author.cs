using System.ComponentModel.DataAnnotations;

namespace CallForPappersService.Data.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        ICollection<Application> Applications { get; set; }
    }
}
