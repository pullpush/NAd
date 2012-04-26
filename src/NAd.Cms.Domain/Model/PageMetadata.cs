
using System;
using System.ComponentModel.DataAnnotations;

namespace NAd.Cms.Domain.Model
{
    /// <summary>
    /// Represents the metadata of the page
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [MetadataType(typeof(PageMetadataMetadata))]
    public class PageMetadata : IPageMetadata {
        /// <summary>
        /// Get/Sets the Name of the PageMetaData
        /// </summary>
        /// <value></value>
        public virtual string Name { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public virtual string Title { get; set; }
        /// <summary>
        /// Gets or sets the keywords.
        /// </summary>
        /// <value>
        /// The keywords.
        /// </value>
        public virtual string Keywords { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public virtual string Description { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [display in menu].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [display in menu]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool DisplayInMenu { get; set; }
        /// <summary>
        /// Gets or sets the published.
        /// </summary>
        /// <value>
        /// The published.
        /// </value>
        public virtual DateTime? Published { get; set; }
        /// <summary>
        /// Gets or sets the changed.
        /// </summary>
        /// <value>
        /// The changed.
        /// </value>
        public virtual DateTime? Changed { get; set; }
        /// <summary>
        /// Gets or sets the published by.
        /// </summary>
        /// <value>
        /// The published by.
        /// </value>
        public virtual string ChangedBy { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is published.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is published; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsPublished { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsDeleted { get; set; }
        /// <summary>
        /// Get/Sets the Slug of the PageMetaData
        /// </summary>
        /// <value></value>
        public virtual string Slug { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public virtual string Url { get; set; }
        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public virtual int SortOrder { get; set; }
    }
}