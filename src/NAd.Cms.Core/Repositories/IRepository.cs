
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NAd.Cms.Core.Repositories {
    /// <summary>
    /// Represents a common repository 
    /// </summary>
    public interface IRepository<in T> {
        /*
        /// <summary>
        /// Singles the or default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        T SingleOrDefault<T>(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Loads the specified ids.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        T[] Load<T>(string[] ids);
        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> List<T>();
        /// <summary>
        /// Stores the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Store(T entity);
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);
        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();
        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        void Refresh(T entity);
        */
    }
}