using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NAd.Framework.Persistence.Abstractions
{
    //public interface ISession : IDisposable
    //{
    //    IQueryable<TEntity> Query<TEntity>() where TEntity : Entity;
    //    void Add<TEntity>(TEntity entity) where TEntity : Entity;
    //    void Update<TEntity>(TEntity entity) where TEntity : Entity;
    //    void Delete<TEntity>(TEntity entity) where TEntity : Entity;
    //    void SaveChanges();

    //    #region Future Load Methods. Can't use now because Raven forces Id's to be strings. If were not for that, we could make this generic between NHibernate and RavenDb.

    //    // TEntity Load<TEntity, TId>(TId id) where TEntity : Entity<TId>;
    //    // IEnumerable<TEntity> Load<TEntity, TId>(IEnumerable<TId> ids) where TEntity : Entity<TId>;

    //    #endregion
    //}
}
