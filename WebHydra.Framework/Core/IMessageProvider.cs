using System;

namespace WebHydra.Framework.Core
{
    public interface IMessageProvider
    {
        bool MessageByName(string name, out Type messageType);
    }
}