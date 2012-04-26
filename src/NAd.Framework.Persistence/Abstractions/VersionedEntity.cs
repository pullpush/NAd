
namespace NAd.Framework.Persistence.Abstractions
{
    public abstract class VersionedEntity<TId> : Entity<TId>, IHaveVersion
        where TId : struct 
    {
        public const long IgnoredVersion = -1;

        public virtual long Version { get; set; }
    }
}