namespace CallForPappersService.Validations.Result
{
    public sealed record Error(string Description = null)
    {
        public static readonly Error None = new(string.Empty);
    }
}   

