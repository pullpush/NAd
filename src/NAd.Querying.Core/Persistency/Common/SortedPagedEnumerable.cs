using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NAd.Querying.Core.Persistency.Common
{
    //http://mosesofegypt.net/post/PagedList-Sorted-Edition.aspx

    public class SortedPagedEnumerable<T, TResult> : List<T>, IPagedEnumerable<T>
    {
        //private readonly IEnumerable<T> _innerEnumerable;

        public SortedPagedEnumerable(IEnumerable<T> source, int index, int pageSize,
            Expression<Func<T, TResult>> keySelector, bool asc)
        {
            if (source is IQueryable<T>)
                Initialize(source as IQueryable<T>, index, pageSize, keySelector, asc);
            else
                Initialize(source.AsQueryable(), index, pageSize, keySelector, asc);
        }

        public SortedPagedEnumerable(IQueryable<T> source, int index, int pageSize,
                Expression<Func<T, TResult>> keySelector, bool asc)
        {
            Initialize(source, index, pageSize, keySelector, asc);
        }


        protected void Initialize(IQueryable<T> source, int index, int pageSize,
                    Expression<Func<T, TResult>> keySelector, bool asc)
        {
            // Method code omitted......
            //### add items to internal list
            if (Total <= 0) return;

            if (asc)
            {
                AddRange(source.OrderBy(keySelector).Skip(index * pageSize).Take(pageSize));
            }
            else
            {
                AddRange(source.OrderByDescending(keySelector).Skip(index * pageSize).Take(pageSize));
            }
        }

        #region IPagedEnumerable<T> Members
        public int Total { get; private set; }
        public int PageCount { get; private set; }
        public int PageNumber { get; private set; }
        #endregion
    }
}
