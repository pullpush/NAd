using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NAd.Framework.Domain;
using NAd.Framework.Persistence.Abstractions;
using NAd.Framework.Persistence.Raven;

namespace NAd.Framework.Hive.Raven
{
    public static class RavenRepositoryExtensions
    {
        public static Classified GetByName(this IQueryable<Classified> repository, Guid id)
        {
            return GetSingle(repository, e => e.Id == id, id);
        }


        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Classified> List(this IQueryableRepository<Classified, Guid> repository)
        {
            //return ListRaven<Classified, Guid>(repository);

            return (repository as IRavenRepository<Classified, Guid>).List();   // as RavenBaseRepository<Classified, Guid>
            //return repository.List();
            //List<Classified>();
        }


        //public static Classified GetPageByUrl(this IQueryableRepository<Classified, Guid> repository)
        //{
        //    return (repository as IRavenRepository<Classified, Guid>).GetPageByUrl();
        //}


        //public static IEnumerable<T> ListRaven<T, TId> (RavenBaseRepository<T, TId> repository)
        //    where T : Entity<TId>
        //    where TId : struct
        //{
            
        //}

        ///// <summary>
        ///// Refreshes the specified entity.
        ///// </summary>
        ///// <param name="entity">The entity.</param>
        //public static void Refresh(this IQueryable<Classified> repository)
        //{
        //    repository.Refresh();
        //}


        // Allow reporting more descriptive error messages.
        private static T GetSingle<T>(IQueryable<T> collection,
            Expression<Func<T, bool>> predicate, object id)
            where T : class
        {
            T entity;

            try
            {
                entity = collection.SingleOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Format(
                    "There was an error retrieving an {0} with " +
                    "id {1}. {2}",
                    typeof(T).Name, id ?? "{null}", ex.Message), ex);
            }

            if (entity == null)
            {
                throw new KeyNotFoundException(string.Format(
                    "{0} with id {1} was not found.",
                    typeof(T).Name, id ?? "{null}"));
            }

            return entity;
        }
    }
}
