namespace WebHydra.Framework.Core
{
    public interface ICqrsBus
    {
        //void Send(ICommand command);

        //TResult Send<TResult>(IQuery<TResult> query);

        object Execute(IMessage message, IWebHydraContext context);
    }
}