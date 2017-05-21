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
        public AppModule(Cqrs _cqrs)
        {
            Post["/api/cqrsbus"] = _ =>
            {
                Console.WriteLine("*** POST REQUEST RECEIVED ***");

                try
                {
                    ICqrsInput cqrsInput = new CqrsInput()
                    {
                        Body = Context.Request.Body.AsString(),
                        Auth = Context.Request.Headers.Authorization
                    };

                    string jsonResult = _cqrs.Exe(cqrsInput);

                    return new TextResponse(jsonResult); // Respond with code 200
                }
                catch (Exception e)
                {
                    Console.WriteLine("EXCEPTION: " + e.Message);
                    
                    if (e is IHttpRespondStatusCode)
                    {
                        return new TextResponse((HttpStatusCode)((IHttpRespondStatusCode)e).StatusCode,
                            contents: "EXCEPTION: " + e.GetType().ToString());
                    }                       

                    return new TextResponse(HttpStatusCode.InternalServerError, e.Message);
                }            
            };


            Get["/test"] = _ =>
            {
                return new TextResponse("test ok");
            };
        }
    }
}
