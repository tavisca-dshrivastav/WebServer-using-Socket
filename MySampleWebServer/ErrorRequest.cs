using System;
using System.Collections.Generic;
using System.Text;

namespace MySampleWebServer
{
    class ErrorRequest
    {
        public static bool IsRequestWithError(Request request)
        {
            if (request == null)
                return true;
            else if (request.Type != "GET")
                return true;
            return false;
        }

    }
}
