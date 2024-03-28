namespace CallForPappersService.Models
{
    public class AuthorModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        ICollection<ApplicationModel> Applications { get; set; }
    }
}
