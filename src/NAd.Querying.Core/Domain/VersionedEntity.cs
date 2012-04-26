
namespace NAd.Querying.Core.Domain
{
    public abstract class VersionedEntity : Entity, IHaveVersion
    {
        public const long IgnoredVersion = -1;

        public virtual long Version { get; set; }
    }
}