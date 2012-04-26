using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using NAd.Common;

namespace NAd.Querying.Core.Persistency.Common
{
    public class PagedEnumerable<T> : IPagedEnumerable<T>
    {
        private readonly IEnumerable<T> _innerEnumerable;

        public int PageCount { get; private set; }
        public int PageNumber { get; private set; }

        public PagedEnumerable(IQueryable<T> queryable, int pageNumber, int pageSize)
        {
            _innerEnumerable = queryable.TakePage(pageNumber, pageSize);
            PageNumber = pageNumber;
            Total = queryable.Count();

            if (Total > 0)
                PageCount = (int)Math.Ceiling(Total / (double)pageSize);
            else
                PageCount = 0;
        }

        public PagedEnumerable(IEnumerable<T> enumerable, int total)
        {
            _innerEnumerable = enumerable;
            PageNumber = 1;
            Total = total;
            PageCount = 1;
        }

        public int Total { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return _innerEnumerable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
