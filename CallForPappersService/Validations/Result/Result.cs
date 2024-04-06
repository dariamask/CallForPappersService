using Microsoft.AspNetCore.Routing.Template;

namespace CallForPappersService.Validations.Result
{
    public class Result<T>
    {
        public T? Value { get; set; }
        public Error? Error { get; }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;

        public Result(T value)
        {
            Value = value;
            Error = Error.None;
            IsSuccess = true;
        }

        public Result(Error error)
        {
            Value = default;
            Error = error;
            IsSuccess = false;
        }

        //public static Result<T> Success(T value) => new(value);
        //public static Result<T> Failure(Error error) => new(error);

        public static implicit operator Result<T>(Error error) => new (error);
        public static implicit operator Result<T>(T Value) => new (Value);
    }
}
