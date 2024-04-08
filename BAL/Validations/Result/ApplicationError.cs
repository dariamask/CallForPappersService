namespace CallForPappersService_BAL.Validations.Result
{
    public static class ApplicationError
    {
        public static readonly Error DoesntExist = new ("Application doesn't exist");
        public static readonly Error PendingAlreadyExist = new ("Unsubmitted application already exists");
        public static readonly Error CantUpdateActive = new ("Can't update application if it is already submitted");
        public static readonly Error CantDeleteActive = new("Can't delete application if it is already submitted");
    }

    public static class AuthorError
    {
        public static readonly Error DoesntExist = new ("Author doesn't exist");
    }
}   

