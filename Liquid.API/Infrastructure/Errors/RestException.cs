using System;
using System.Net;

namespace Liquid.API.Infrastructure.Errors
{
    public class RestException : Exception
    {
        public RestException(HttpStatusCode code, object? errors = null)
        {
            Code = code;
            Errors = errors;
        }

        public object? Errors { get; set; }

        public HttpStatusCode Code { get; }
    }

    public class GenericRestException
    {
        public string Errors { get; set; }
    }
}
