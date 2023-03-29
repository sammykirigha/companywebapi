using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebApi.Responses
{
    public class AuthResponse
    {
        public int? StatusCode { get; set; }

        public string? Status { get; set; }

        public string? statusMessage { get; set; }

        public AuthResponse(int statusCode, string status, string message)
        {
            StatusCode = statusCode;
            Status = status;
            statusMessage = message;
        }
    }
}