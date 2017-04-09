using System.Net;

namespace WebHydra.Framework.Core
{
    public interface IHttpRespondStatusCode
    {
        HttpStatusCode StatusCode { get; }
    }
}