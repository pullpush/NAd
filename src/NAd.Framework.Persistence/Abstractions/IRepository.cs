using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NAd.Framework.Persistence.Abstractions
{
    public interface IRepository<T, in TId> : ICreate<T>, IRead<T, TId>, IRemove<T>, IUpdate<T>, ISaveOrUpdate<T>
        where T : class, IEntity<TId> 
        where TId : struct
    { }

    public interface IRemove<in T>
    {
        void Remove(T entity);
    }

    public interface IRead<T, in TId>
        where T : class, IEntity<TId>
        where TId : struct
    {        
        T Get(TId id);
        T Load(TId id);
        T FindBy(Expression<Func<T, bool>> expression);
        IQueryable<T> FilterBy(Expression<Func<T, bool>> expression);

        IEnumerable<T> Get(IEnumerable<TId> ids);
        //IEnumerable<T> Find(Func<T, bool> where);
    }

    public interface ICreate<in T>
    {
        void Add(T entity);
    }

    public interface IUpdate<in T>
    {
        void Update(T entity);
    }

    public interface ISaveOrUpdate<in T>
    {
        void Save(T entity);
    }
}
