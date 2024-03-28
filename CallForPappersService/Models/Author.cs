namespace CallForPappersService.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        ICollection<Application> Applications { get; set; }
    }
}
