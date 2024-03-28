namespace CallForPappersService.Models
{
    public class ActivityTypeModel
    {
        public int Id { get; set; }
        public string Activity { get; set; }
        public string Description { get; set; }
        ICollection<ApplicationModel> Applications { get; set; }
    }
}
