using System;
using System.Net;
using WebHydra.Framework.Core;

namespace NotesApi.Handlers
{
    public class AuthorizationException : Exception, IHttpRespondStatusCode
    {
        public HttpStatusCode StatusCode
        {
            get { return HttpStatusCode.Unauthorized; }
        }
    }
}