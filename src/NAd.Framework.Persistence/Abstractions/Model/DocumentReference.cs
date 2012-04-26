
namespace NAd.Framework.Persistence.Abstractions.Model
{
    /// <summary>
    /// Used as reference between documents in RavenDB
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class DocumentReference<T> : IDocumentReference where T : IPageModel {
        
        /// <summary>
        /// Get/Sets the Id of the DocumentReference
        /// </summary>
        /// <value></value>
        public string Id { get; set; }
        
        /// <summary>
        /// Get/Sets the Slug of the DocumentReference
        /// </summary>
        /// <value></value>
        public string Slug { get; set; }

        /// <summary>
        /// Implicitly converts a page model to a DocumentReference
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        //public static implicit operator DocumentReference<T>(T document) {
        //    return new DocumentReference<T>
        //               {
        //                   Id = document.Id,
        //                   Slug = document.Metadata.Slug
        //               };
        //}
    }
}