using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public record LoginResponse(string? token, User? user, HttpStatusCode statusCode, string message): ApiResponse(statusCode, message);
}
