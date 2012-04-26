
using System.Linq;

namespace NAd.Common.Paging
{
    //AI: also read this http://www.squaredroot.com/2009/06/15/return-of-the-pagedlist/
    //and this one http://mosesofegypt.net/post/PagedList-Sorted-Edition.aspx

    public static class PagedEnumerableExtensions
    {
        public static IPagedEnumerable<T> AsPaged<T>(this IQueryable<T> superset, int index, int pageSize)
        {
            return new PagedEnumerable<T>(superset, index, pageSize);
        }
    }
}
