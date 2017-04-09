using Newtonsoft.Json;

namespace WebHydra.Framework.Core
{
    public class PackageProvider : IPackageProvider
    {   
        public IPackage PackageAsJsonToPackage(string packageAsJson)
        {
            return JsonConvert.DeserializeObject<Package>(packageAsJson);
        }
    }
}