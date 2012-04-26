
namespace NAd.Framework.Persistence
{
    public interface IUnitOfWorkFactory<out TUnitOfWork> where TUnitOfWork : UnitOfWork
    {
        TUnitOfWork Create();
    }
}