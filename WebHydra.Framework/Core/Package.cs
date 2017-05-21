using WebHydra.Framework.Utils;

namespace WebHydra.Framework.Core
{
    public class Package : IPackage
    {
        public string ClassName { get; set; }
        public string ClassProperties { get; set; }

        public override string ToString()
        {
            return Dump.Props(this);
        }
    }
}