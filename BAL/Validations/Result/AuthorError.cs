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

        public List<IError> Reasons => throw new NotImplementedException();
        public string Message => throw new NotImplementedException();
        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}
