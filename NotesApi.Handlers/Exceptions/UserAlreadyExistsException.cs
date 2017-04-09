using System;
using System.Net;
using System.Runtime.Serialization;
using WebHydra.Framework.Core;

namespace NotesApi.Handlers
{
    internal class UserAlreadyExistsException : Exception, IHttpRespondStatusCode
    {
        public HttpStatusCode StatusCode
        {
            get { return HttpStatusCode.NotAcceptable; }
        }
    }
}