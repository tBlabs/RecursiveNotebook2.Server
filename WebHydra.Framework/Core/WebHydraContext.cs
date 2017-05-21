using WebHydra.Framework.Utils;

namespace WebHydra.Framework.Core
{
    public class WebHydraContext : IWebHydraContext
    {
        public User User { get; set; }

        public override string ToString()
        {
            return Dump.Props(this);
        }
    }
}