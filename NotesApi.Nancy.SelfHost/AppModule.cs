using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Nancy;
using Nancy.Extensions;
using Nancy.Responses;
using WebHydra.Framework.Core;
using Newtonsoft.Json;
using NotesApi.Auth;
using WebHydra.Framework;

namespace NotesApi.Nancy.SelfHost
{
    public class AppModule : NancyModule
    {
        public AppModule(
            IMessageBuilder _messageBuilder,
            ICqrsBus _cqrsBus,
            IAuth _auth)
        {
            Post["/api/cqrsbus"] = _ =>
            {
                Console.WriteLine("*** POST REQUEST RECEIVED ***");

                try
                {
                    IWebHydraContext context = new WebHydraContext();

                    string authToken = Context.Request.Headers.Authorization;

                    context.User = _auth.GetUserFromToken(authToken);

                    if (context.User != null)
                    {
                        Console.WriteLine(context.User.ToString());
                    }
                    else Console.WriteLine("No user");


                    string body = Context.Request.Body.AsString();

                    var d = JsonConvert.DeserializeObject<Dictionary<string, object>>(body);
                    IPackage package = new Package();
                    package.ClassName = d.Keys.First();
                    package.ClassProperties = d.Values.First().ToString();

                    IMessage message = _messageBuilder.BuildMessageFromPackage(package);

                    Console.WriteLine("Executing " + message.ToString() + "...");

                    var ret = _cqrsBus.Execute(message, context);

                    string json = JsonConvert.SerializeObject(ret);

                    Console.WriteLine("Returned json: " + json);

                    return new TextResponse(HttpStatusCode.OK, json);
                }

                catch (Exception e)
                {
                    Console.WriteLine("EX: " + e.Message);

                    if (e is MessageNotFoundException)
                    {
                        return new TextResponse(HttpStatusCode.InternalServerError, contents: e.Message);
                    }

                    if (e is IHttpRespondStatusCode)
                    {
                        return new TextResponse((HttpStatusCode)((IHttpRespondStatusCode)e).StatusCode, contents: "EXCEPTION: " + e.GetType().ToString());
                    }

                    return new TextResponse(HttpStatusCode.InternalServerError);
                }
            };


            Get["/test"] = _ =>
            {
                return new TextResponse("test ok");
            };
        }
    }
}
