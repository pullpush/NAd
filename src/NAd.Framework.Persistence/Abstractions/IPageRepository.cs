using NAd.Framework.Persistence.Abstractions.Model;

namespace NAd.Framework.Persistence.Abstractions
{
    public interface IPageRepository<T, in TId> : IRepository<T, TId>
        where T : class, IEntity<TId>
        where TId : struct
    {
        IPageModel GetPageByUrl(string url);
    }
}