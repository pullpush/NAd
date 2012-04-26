
using System.ComponentModel.DataAnnotations;

namespace NAd.Framework.Persistence.Abstractions.Model
{
    internal class PageModelMetadata {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [ScaffoldColumn(false)]
        public string Id { get; set; }
        /// <summary>
        /// Gets the meta data.
        /// </summary>
        [ScaffoldColumn(false)]
        public virtual IPageMetadata Metadata { get; private set; }
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        [ScaffoldColumn(false)]
        public virtual DocumentReference<IPageModel> Parent { get; set; }
    }
}
