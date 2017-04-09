using System.Diagnostics.CodeAnalysis;

namespace WebHydra.Framework.Core
{
    [SuppressMessage("ReSharper", "UnusedTypeParameter")]
    public interface IQuery<out TResult> : IQueryBase { }
}
