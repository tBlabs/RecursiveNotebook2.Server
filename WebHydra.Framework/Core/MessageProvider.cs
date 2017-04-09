using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;

namespace WebHydra.Framework.Core
{
    // Singleton
    public class MessageProvider : IMessageProvider
    {
        private readonly Dictionary<string, Type> _messageNameToType;

        public MessageProvider(IComponentContext serviceLocator)
        {
            _messageNameToType = serviceLocator.ComponentRegistry.Registrations.SelectMany(x => x.Services)
                .OfType<IServiceWithType>()
                .Select(x => x.ServiceType)
                .Where(e => e.IsClass)
                .Where(e => e.IsAssignableTo<IMessage>())
                .Distinct()
                .ToDictionary(type => type.Name, type => type);
        }

        public bool MessageByName(string name, out Type messageType)
        {
            return _messageNameToType.TryGetValue(name, out messageType);
        }   
    }
}