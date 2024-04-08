

namespace CallForPappersService_BAL.Validations.Result
{
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public Error Error { get; private set; }
        public bool IsFailure => !IsSuccess;

        protected Result() { }
        protected internal Result(Error error)
        {
            Error = error;
        }
        protected Result(bool isSuccess, Error error) 
        { 
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new (false, error);

        public static implicit operator Result(Error error) => Failure(error);
    }

    public class Result<T> : Result
    {
        public T Value { get; set; }

        protected internal Result(T value)
            : base()
        {
            Value = value;           
        }

        protected internal Result(Error error)
            : base(error) {}

        public static implicit operator Result<T>(Error error) => new (error);
        public static implicit operator Result<T>(T value) => new(value);
    }
}
