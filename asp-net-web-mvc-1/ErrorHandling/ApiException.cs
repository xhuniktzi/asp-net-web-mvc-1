using System;

namespace asp_net_web_mvc_1.ErrorHandling
{
    public class ApiException: Exception
    {
        public ApiException() { }

        public ApiException(string message): base(message) { }

        public ApiException(string message, Exception inner): base(message, inner) { }
    }
}