
namespace NAd.Querying.Core.Domain
{
    /// <summary>
    /// Marks an object as a domain object which identity is determined by a single identifier.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets the unique identifier of this entity.
        /// </summary>
        object Id { get; }
    }

    /// <summary>
    /// Marks an entity as the root of an aggregate.
    /// </summary>
    //public interface IAggregateRoot : IEntity
    //{
    //}
}