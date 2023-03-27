using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebApi.Exceptions
{
    public class EmployeeErrorHandler : ErrorHandlerException
    {
        private const string DefaultMessage = "User already exist with that email!! Email taken";

        public string? Email { get; }

        public EmployeeErrorHandler() : base(DefaultMessage)
        { }

        public EmployeeErrorHandler(Exception innerException) : base(DefaultMessage, innerException)
        { }

        public EmployeeErrorHandler(string message, Exception innerException) : base(message, innerException)
        { }

        public EmployeeErrorHandler(string email) : base(DefaultMessage) => Email = email;
    }
}