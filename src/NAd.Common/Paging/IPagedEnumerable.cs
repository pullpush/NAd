using System.Collections.Generic;

namespace NAd.Common.Paging
{
    public interface IPagedEnumerable<T> : IEnumerable<T>
    {
        int Total { get; }
        int PageCount { get; }
        int PageNumber { get; }
    }
}