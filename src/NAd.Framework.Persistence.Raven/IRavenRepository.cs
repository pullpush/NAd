using System.Collections.Generic;
using NAd.Framework.Persistence.Abstractions;

namespace NAd.Framework.Persistence.Raven
{
    public interface IRavenRepository<T, in TId> : IQueryableRepository<T, TId>
        where T : class, IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> List();

        /// <summary>
        /// Refreshes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Refresh(T entity);
    }
}
