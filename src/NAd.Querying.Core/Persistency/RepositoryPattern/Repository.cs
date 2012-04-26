using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using NAd.Common;
using NAd.Querying.Core.Domain;
using NAd.Querying.Core.ExceptionHandling;
using NAd.Querying.Core.Persistency.Common;

namespace NAd.Querying.Core.Persistency.RepositoryPattern
{
    public abstract class Repository<T> : IQueryable<T> where T : class, IEntity
    {
        protected abstract IQueryable<T> Entities { get; }

        public Type ElementType
        {
            get { return Entities.ElementType; }
        }

        public Expression Expression
        {
            get { return Entities.Expression; }
        }

        public IQueryProvider Provider
        {
            get { return Entities.Provider; }
        }

        public T GetById(object id)
        {
            var entity = Entities.SingleOrDefault(e => e.Id == id);

            //var entity = Entities.SingleOrDefault(e => e.Id.Equals(id));

            //if (entity == null)
            //{
            //    throw new ApplicationErrorException(ServiceError.RecordDoesNotExistAnymore)
            //    {
            //        { "Entity",  typeof(T).Name}
            //    };
            //}

            return entity;
        }

        public void SaveRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Save(entity);
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }


        public abstract void Save(T entity);
        public abstract T Load(object entity);
        public abstract T Get(object entity);
        //public abstract void Add(T entity);
        public abstract void Remove(T entity);

        public IEnumerator<T> GetEnumerator()
        {
            return Entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Entities.GetEnumerator();
        }


        //public abstract IQueryable<T> All();

        public T FindBy(Expression<Func<T, bool>> expression)
        {
            return FilterBy(expression).SingleOrDefault();
        }

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            return Entities.Where(expression).AsQueryable();
        }

        public IPagedEnumerable<T> FilterBy(Expression<Func<T, bool>> expression, int pageIndex, int pageSize)
        {
            return Entities.Where(expression).AsQueryable().AsPaged(pageIndex, pageSize);
            //return new PagedEnumerable<T>(FilterBy(expression), pageIndex, pageSize);
        }

        // Extension method for easy use
        /*
        public static PagedEnumerable<T> AsPaged(this IEnumerable collection, int currentPage = 1, int pageSize = 0)
        {
            return new PagedEnumerable<T>(collection, currentPage, pageSize);
        }*/
    }
}