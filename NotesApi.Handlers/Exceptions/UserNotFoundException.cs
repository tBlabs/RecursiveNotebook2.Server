using System;
using System.Net;
using WebHydra.Framework.Core;

namespace NotesApi.Handlers
{
    public class UserNotFoundException : Exception, IHttpRespondStatusCode
    {
        public HttpStatusCode StatusCode
        {
            get { return HttpStatusCode.NotFound; }
        }
    }
}