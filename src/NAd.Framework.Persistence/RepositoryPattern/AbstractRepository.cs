using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NAd.Framework.Persistence.Abstractions;
using NAd.Framework.Persistence.Abstractions.Model;

namespace NAd.Framework.Persistence.RepositoryPattern
{
    //public abstract class BaseRepository<T, TId> : IRepository<T, TId> where T : Entity<TId>
    public abstract class AbstractRepository<T, TId> : IQueryableRepository<T, TId> //IRepository<T, TId>, IQueryable<T> 
        where T : class, IEntity<TId>
        where TId: struct 
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



        public IEnumerator<T> GetEnumerator()
        {
            return Entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Entities.GetEnumerator();
        }



        public virtual T GetById(TId id)
        {
            var entity = Entities.SingleOrDefault(e => e.Id.Equals(id));

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


        #region IRead<T,TId> Members

        public abstract T Get(TId id);
        //public T Get(TId id)
        //{
        //    throw new NotImplementedException();
        //}

        public abstract T Load(TId id);
        //public T Load(TId id)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<T> Get(IEnumerable<TId> ids)
        {
            var idList = ids.ToList();

            return Entities.Where(e => idList.Contains(e.Id));
        }

        public T FindBy(Expression<Func<T, bool>> expression)
        {
            return FilterBy(expression).SingleOrDefault();
        }

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            return Entities.Where(expression).AsQueryable();
        }

        #endregion

        #region IDelete<T> Members

        public abstract void Remove(T entity);
        //public void Remove(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region IUpdate<T> Members

        public abstract void Update(T entity);
        //public void Update(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region ICreate<T> Members

        public abstract void Add(T entity);
        //public void Add(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        public abstract void Save(T entity);

        public abstract IPageModel GetPageByUrl(string url);


        /*
        public void Add(T entity)
        {
            UnitOfWork.CurrentSession.Add(entity);
        }

        public IQueryable<T> All()
        {
            return UnitOfWork.CurrentSession.Query<T>();
        }

        public virtual T Get(TId id)
        {
            return All().Where(e => e.Id.Equals(id)).SingleOrDefault();
        }

        public IEnumerable<T> Get(IEnumerable<TId> ids)
        {
            var idList = ids.ToList();

            return All().Where(e => idList.Contains(e.Id));
        }

        public void Delete(T entity)
        {
            UnitOfWork.CurrentSession.Delete(entity);
        }

        public void Update(T entity)
        {
            UnitOfWork.CurrentSession.Update(entity);
        }
        */
    }
}
