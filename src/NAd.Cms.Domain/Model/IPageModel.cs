
using System.Collections.Generic;

namespace NAd.Cms.Domain.Model
{
    /// <summary>
    /// Represents the page model
    /// </summary>
    public interface IPageModel : IDocument {

        /// <summary>
        /// Gets the meta data.
        /// </summary>
        IPageMetadata Metadata { get; }
        
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        //DocumentReference<IPageModel> Parent { get; set; }
    }
}