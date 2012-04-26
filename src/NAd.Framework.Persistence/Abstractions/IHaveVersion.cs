
namespace NAd.Framework.Persistence.Abstractions
{
    /// <summary>
    /// Specifies that an entity has a version for detecting concurrency conflicts
    /// </summary>
    public interface IHaveVersion
    {
        /// <summary>
        /// Gets the version of the current entity.
        /// </summary>
        long Version { get; }

        //long IgnoredVersion { get; }
    }
}