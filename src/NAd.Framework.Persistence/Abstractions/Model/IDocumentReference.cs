
namespace NAd.Framework.Persistence.Abstractions.Model
{
    public interface IDocumentReference {
        /// <summary>
        /// Get/Sets the Id of the DenormalizedReference
        /// </summary>
        /// <value></value>
        string Id { get; set; }
        /// <summary>
        /// Get/Sets the Slug of the DenormalizedReference
        /// </summary>
        /// <value></value>
        string Slug { get; set; }
    }
}