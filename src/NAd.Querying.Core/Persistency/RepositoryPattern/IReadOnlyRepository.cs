using System;
using System.Linq;
using System.Linq.Expressions;

namespace NAd.Querying.Core.Persistency.RepositoryPattern
{
    public interface IReadOnlyRepository<TKey, TEntity> where TEntity : class, IEntityKey<TKey>
    {
        IQueryable<TEntity> All();
        TEntity FindBy(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);
        TEntity FindBy(TKey id);
    }
}
