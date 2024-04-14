using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallForPappersService_BAL.Validations.Result
{
    public class AuthorError : IError
    {
        public static readonly Error DoesntExist = new("Author doesn't exist");
        public List<IError> Reasons => new List<IError>();
        public string Message => string.Empty;
        public Dictionary<string, object> Metadata => new Dictionary<string, object>();
    }
}
