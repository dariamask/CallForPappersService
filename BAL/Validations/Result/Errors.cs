namespace CallForPappersService_BAL.Validations.Result
{
    public class Errors
    {
        //application
        public const string ApplicationDoesntExist = "Application doesn't exist";
        public const string PendingAlreadyExist = "Unsubmitted application already exists";
        public const string NoUnsubmitted = "This author doesnt have unsumbitted application";
        public const string CantUpdateActive = "Can't update application if it is already submitted";
        public const string CantDeleteActive = "Can't delete application if it is already submitted";
        public const string MustBeFilledIn = "Fields Name and Outline must be filled in to submit application";

        //author
        public const string AuthorDoesntExist = "Author doesn't exist";

    }
}   

