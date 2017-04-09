namespace WebHydra.Framework.Core
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command, IWebHydraContext context);
    }
}