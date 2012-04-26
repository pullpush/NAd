
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NAd.Framework.Persistence.Abstractions.Model
{
    /// <summary>
    /// The base class for page models
    /// </summary>
    /// <remarks>Use IPageModel to create your own base class</remarks>
    /// <example></example>
    [MetadataType(typeof(PageModelMetadata))]
    public abstract class PageModel : IPageModel {
        
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        //public string Id { get; set; }

        /// <summary>
        /// Gets the meta data.
        /// </summary>
        public virtual IPageMetadata Metadata { get; private set; }
        
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        public virtual DocumentReference<IPageModel> Parent { get; set; }
        
        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        internal List<string> Children { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="PageModel"/> class.
        /// </summary>
        protected PageModel() {
            Metadata = new PageMetadata();
            Children = new List<string>();
        }
    }
}