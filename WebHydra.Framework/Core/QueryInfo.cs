using System;
using System.Diagnostics;
using System.Linq;

namespace WebHydra.Framework.Core
{
    [DebuggerDisplay("{QueryType.Name,nq}")]
    public sealed class QueryInfo
    {
        public readonly Type QueryType;
        public readonly Type ResultType;

        public QueryInfo(Type queryType)
        {
            if (!typeof(IQueryBase).IsAssignableFrom(queryType))
                throw new ArgumentException($"{queryType.FullName} does not inherit from: {typeof(IQueryBase).FullName}");

            QueryType = queryType;
            ResultType = DetermineResultType(queryType);
        }

        private static Type DetermineResultType(Type type)
        {
            return type.GetInterfaces()
                .Single(e => e.IsGenericType && e.GetGenericTypeDefinition() == typeof(IQuery<>))
                .GetGenericArguments()[0];
        }
    }
}
