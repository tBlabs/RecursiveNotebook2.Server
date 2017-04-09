namespace WebHydra.Framework.Core
{
    public interface IPackageProvider
    {
        IPackage PackageAsJsonToPackage(string packageAsJson);
    }
}