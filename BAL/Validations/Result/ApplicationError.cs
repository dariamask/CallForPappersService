using FluentResults;

namespace CallForPappersService_BAL.Validations.Result
{
    public class ApplicationError : IError
    {
        public static readonly Error DoesntExist = new ("Application doesn't exist");
        public static readonly Error PendingAlreadyExist = new ("Unsubmitted application already exists");
        public static readonly Error NoUnsubmitted = new ("This author doesnt have unsumbitted application");
        public static readonly Error CantUpdateActive = new ("Can't update application if it is already submitted");
        public static readonly Error CantDeleteActive = new("Can't delete application if it is already submitted");

        public List<IError> Reasons => new List<IError>();
        public string Message => string.Empty;
        public Dictionary<string, object> Metadata => new Dictionary<string, object>();
    }
}   

