using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebApi.Exceptions
{
    public class ErrorHandlerException : Exception
    {
        private const string DefaultMessage = "An Error occurred during api call: Internal error occurred ";

        //  creates new exception error with default message
        public ErrorHandlerException() : base(DefaultMessage)
        { }

        //  creates new exception error with supplied message
        public ErrorHandlerException(string message) : base(message)
        { }

        //  creates new exception error with predefined message
        public ErrorHandlerException(Exception innerException) : base(DefaultMessage, innerException)
        { }

        //  creates new exception error with supplied message and a wrapped inner exception
        public ErrorHandlerException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}