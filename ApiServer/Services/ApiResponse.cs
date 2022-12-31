using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public record ApiResponse(HttpStatusCode StatusCode, string Message);
}
