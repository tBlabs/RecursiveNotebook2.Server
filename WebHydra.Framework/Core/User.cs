using System;

namespace WebHydra.Framework.Core
{
    public class User
    {
        public Guid Id { get; set; }
        public Claims Claims { get; set; } = new Claims();

        public override string ToString()
        {
            return $"User: id={Id}, claims: {Claims.ToString()}";
        }
    }
}
