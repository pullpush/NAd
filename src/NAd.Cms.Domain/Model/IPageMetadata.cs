
using System;

namespace NAd.Cms.Domain.Model
{
    /// <summary>
    /// Represents the page metadata
    /// </summary>
    public interface IPageMetadata {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        string Title { get; set; }
        /// <summary>
        /// Gets or sets the keywords.
        /// </summary>
        /// <value>
        /// The keywords.
        /// </value>
        string Keywords { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [display in menu].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [display in menu]; otherwise, <c>false</c>.
        /// </value>
        bool DisplayInMenu { get; set; }
        /// <summary>
        /// Gets or sets the published.
        /// </summary>
        /// <value>
        /// The published.
        /// </value>
        DateTime? Published { get; set; }
        /// <summary>
        /// Gets or sets the changed.
        /// </summary>
        /// <value>
        /// The changed.
        /// </value>
        DateTime? Changed { get; set; }
        /// <summary>
        /// Gets or sets the published by.
        /// </summary>
        /// <value>
        /// The published by.
        /// </value>
        string ChangedBy { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is published.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is published; otherwise, <c>false</c>.
        /// </value>
        bool IsPublished { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        bool IsDeleted { get; set; }
        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        /// <value>
        /// The slug.
        /// </value>
        string Slug { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        string Url { get; set; }
        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        int SortOrder { get; set; }
    }
}