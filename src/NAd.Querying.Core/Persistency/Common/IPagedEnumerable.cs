using System.Collections.Generic;

namespace NAd.Querying.Core.Persistency.Common
{
    public interface IPagedEnumerable<T> : IEnumerable<T>
    {
        int Total { get; }
        int PageCount { get; }
        int PageNumber { get; }
    }
}