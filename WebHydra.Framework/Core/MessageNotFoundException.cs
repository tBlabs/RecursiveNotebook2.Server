using System;

namespace WebHydra.Framework.Core
{
    public class MessageNotFoundException : Exception
    {
        public MessageNotFoundException(string message) : base(message)
        {
        }
    }
}