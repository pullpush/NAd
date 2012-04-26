using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAd.Framework.Persistence.Abstractions.Model;

namespace NAd.Framework.Persistence.Abstractions
{
    public interface IQueryableRepository<T, in TId> : IPageRepository<T, TId>, IQueryable<T>
        where T : class, IEntity<TId>
        where TId : struct
    {
        //IPageModel GetPageByUrl(string url);
    }
}
