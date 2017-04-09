namespace WebHydra.Framework.Core
{
    public interface IQueryHandler<in T1, out T2>
    {
        T2 Handle(T1 query, IWebHydraContext context);
    }
}