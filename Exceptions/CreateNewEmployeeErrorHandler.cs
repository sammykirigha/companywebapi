using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebApi.Exceptions
{
    public class CreateNewEmployeeErrorHandler : ErrorHandlerException
    {
        private const string DefaultMessage = "User already exist with that email!! Email taken";

        public string? Email { get; }

        public CreateNewEmployeeErrorHandler() : base(DefaultMessage)
        { }

        public CreateNewEmployeeErrorHandler(Exception innerException) : base(DefaultMessage, innerException)
        { }

        public CreateNewEmployeeErrorHandler(string message, Exception innerException) : base(message, innerException)
        { }

        public CreateNewEmployeeErrorHandler(string email) : base(DefaultMessage) => Email = email;
    }
}