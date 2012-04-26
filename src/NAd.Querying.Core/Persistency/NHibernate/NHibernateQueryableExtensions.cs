using System;
using System.Linq;
using System.Linq.Expressions;

using NHibernate.Linq;

namespace NAd.Querying.Core.Persistency.NHibernate
{
    public static class NHibernateQueryableExtensions
    {
        public static IQueryable<TEntity> CacheIn<TEntity>(this IQueryable<TEntity> queryable, string regionName)
        {
            return queryable.Cacheable().CacheRegion(regionName);
        }

        public static IQueryable<TEntity> Expand<TEntity, TAssociation>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, TAssociation>> propertySelector)
        {
            //AI: commented out os there's no such class in NH3.2
            //if (queryable.Provider is NhQueryProvider)
            //{
            //    return queryable.Fetch(propertySelector);
            //}
            //else
            //{
            //    return queryable;
            //}
            return queryable;
        }

        //TODO: Need to figure out how to do this in NH 3.x (Dennis)

//        public static IQueryable<TEntity> DistinctDeferred<TEntity>(this IQueryable<TEntity> queryable)
//        {
//            var nHibernateQueryable = queryable as INHibernateQueryable<TEntity>;
//            if (nHibernateQueryable != null)
//            {
//                nHibernateQueryable.QueryOptions.RegisterCustomAction(
//                    c => c.SetResultTransformer(new DistinctRootEntityResultTransformer()));
//            }
//
//            return queryable;
//        }
    }
}