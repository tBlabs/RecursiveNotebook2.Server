using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebHydra.Framework.Core
{
    public interface ICqrsInput
    {
        string Body { get; set; }
        string Auth { get; set; }
    }
    public class CqrsInput : ICqrsInput
    {
        public string Body { get; set; }
        public string Auth { get; set; }
    }

    public class Cqrs
    {
        private readonly IMessageBuilder _messageBuilder;
        private readonly IAuth _auth;
        private readonly ICqrsBus _cqrsBus;
        private readonly IJsonMessageToPackageConverter _jsonMessageToPackageConverter;

        public Cqrs(
            IMessageBuilder messageBuilder, 
            IAuth auth,
            ICqrsBus cqrsBus,
            IJsonMessageToPackageConverter jsonMessageToPackageConverter)
        {
            _messageBuilder = messageBuilder;
            _auth = auth;
            _cqrsBus = cqrsBus;
            _jsonMessageToPackageConverter = jsonMessageToPackageConverter;
        }

        public string Exe(ICqrsInput input)
        {
            IWebHydraContext context = new WebHydraContext()
            {
                User = _auth.GetUserFromToken(input.Auth)
            };

            Console.WriteLine(context.ToString());


            IPackage package = _jsonMessageToPackageConverter.Convert(input.Body);
            IMessage message = _messageBuilder.BuildMessageFromPackage(package);

            Console.WriteLine("Executing " + message + "...");

            var ret = _cqrsBus.Execute(message, context);

            string json = JsonConvert.SerializeObject(ret);

            Console.WriteLine($"Message result: {json}.");

            return json;
        }
    }



    public interface IJsonMessageToPackageConverter
    {
        IPackage Convert(string json);
    }

    public class JsonMessageToPackageConverter : IJsonMessageToPackageConverter
    {
        public IPackage Convert(string json)
        {
            var d = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            IPackage package = new Package();
            package.ClassName = d.Keys.First();
            package.ClassProperties = d.Values.First().ToString();

            return package;
        }
    }
}
