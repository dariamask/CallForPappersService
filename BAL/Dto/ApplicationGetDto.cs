namespace CallForPappersService_BAL.Dto
{
    public class ApplicationGetDto
    {
        public DateTime? SubmittedAfter { get; set; }
        public DateTime? UnsubmittedOlder { get; set; }
    }
}
