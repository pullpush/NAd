namespace NAd.Querying.Core.Persistency.Common
{
    public interface IUnitOfWorkFactory<out TUnitOfWork> where TUnitOfWork : UnitOfWork
    {
        TUnitOfWork Create();
    }
}