namespace WebHydra.Framework.Core
{
    public interface IMessageBuilder
    {
        IMessage BuildMessageFromPackage(IPackage package);
    }
}
