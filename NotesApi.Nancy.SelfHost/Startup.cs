using Autofac;
using Nancy.Bootstrappers.Autofac;
using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac.Core.Lifetime;
using AutoMapper;
using Nancy;
using Nancy.Bootstrapper;
using Newtonsoft.Json;
using WebHydra.Framework.Core;
using NotesApi.Models;
using NotesApi.Data;
using WebHydra.Framework;

namespace NotesApi.Nancy.SelfHost
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        protected override void ApplicationStartup(ILifetimeScope existingContainer, IPipelines pipelines)
        {
            pipelines.AfterRequest += (ctx) =>
            {
                ctx.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                ctx.Response.Headers.Add("Access-Control-Allow-Headers", "Content-type, Authorization");
                ctx.Response.Headers.Add("Access-Control-Allow-Methods", "POST");
            };



            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof(WebHydra.Framework.Autofac.AutofacModule).Assembly);
            builder.RegisterAssemblyModules(typeof(Handlers.Autofac.AutofacModule).Assembly);
            builder.RegisterAssemblyModules(typeof(Models.Autofac.AutofacModule).Assembly);
            builder.RegisterAssemblyModules(typeof(Data.AutofacModule).Assembly);
            builder.RegisterAssemblyModules(typeof(Auth.AutofacModule).Assembly);

            builder.Update(existingContainer.ComponentRegistry);
        }
    }

    public class Program
    {       
        public static void Main(string[] args)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<AddNoteCommand, Note>();
                config.CreateMap<UpdateNoteCommand, Note>();
                config.CreateMap<Note, NoteDto>();
                config.CreateMap<NoteDto, Note>();
            });

            try
            {
                const string URL = "http://localhost:1234";

                var c = new HostConfiguration();
                c.UrlReservations = new UrlReservations() { CreateAutomatically = true };
               
                using (var host = new NancyHost(c, new Uri(URL)))
                {                   
                    host.Start();
                    Console.WriteLine("Running on "+URL);
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("EX: "+ex.Message+ex.StackTrace);
                Console.ReadLine();
            }
        }
    }
}
