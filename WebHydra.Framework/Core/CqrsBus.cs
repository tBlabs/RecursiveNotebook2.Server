using System;
using Autofac;

namespace WebHydra.Framework.Core
{
    public class CqrsBus : ICqrsBus
    {
        private readonly IComponentContext _serviceLocator;

        public CqrsBus(IComponentContext serviceLocator)
        {
            _serviceLocator = serviceLocator;

        }
  
        public object Execute(IMessage message, IWebHydraContext context)
        {
            dynamic handler = GetHandler(message);

            if (message is IQueryBase)
                return handler.Handle((dynamic)message, context);

            handler.Handle((dynamic)message, context);

            return null;
        }
        
        private object GetHandler(IMessage message)
        {
            object handler = null;
            var messageType = message.GetType();

            if (message is IQueryBase)
            {
                var handlerType = typeof(IQueryHandler<,>).MakeGenericType(messageType, new QueryInfo(messageType).ResultType);
                handler = _serviceLocator.ResolveOptional(handlerType);
            }

            if (message is ICommand)
            {
                var handlerType = typeof(ICommandHandler<>).MakeGenericType(messageType);
                handler = _serviceLocator.ResolveOptional(handlerType);
            }

            if (handler == null)
                throw new Exception($"Handler for message: {messageType.FullName} not found.");

            return handler;
        }
    }
}