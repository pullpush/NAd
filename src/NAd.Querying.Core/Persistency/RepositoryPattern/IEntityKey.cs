
namespace NAd.Querying.Core.Persistency.RepositoryPattern
{
    public interface IEntityKey<TKey>
    {
        /// <summary>
        /// Gets the unique identifier of this entity.
        /// </summary>
        TKey Id { get; }
    }
}
