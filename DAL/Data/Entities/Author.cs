using System.ComponentModel.DataAnnotations;

namespace CallForPappersService_DAL.Data.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        ICollection<Application> Applications { get; set; }
    }
}
