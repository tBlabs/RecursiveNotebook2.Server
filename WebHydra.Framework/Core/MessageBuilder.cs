using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebHydra.Framework.Core;

namespace WebHydra.Framework.Core
{
    public class MessageBuilder : IMessageBuilder
    {
        private readonly IMessageProvider _messageProvider;

        public MessageBuilder(IMessageProvider provider)
        {
            _messageProvider = provider;
        }

        public IMessage BuildMessageFromPackage(IPackage package)
        {
            Type messageType;
            if (_messageProvider.MessageByName(package.ClassName, out messageType))
            {
                return (IMessage)JsonConvert.DeserializeObject(package.ClassProperties, messageType);
            }
            else throw new MessageNotFoundException($"Unable to find message {package.ClassName}");
        }
    }
}
