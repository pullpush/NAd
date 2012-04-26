
using System.ComponentModel.DataAnnotations;

namespace NAd.UI.PageModels
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseEditorial : BaseModel {
        /// <summary>
        /// Gets or sets the heading.
        /// </summary>
        /// <value>
        /// The heading.
        /// </value>
        [Required]
        [Display(Order = 100)]
        public virtual string Heading { get; set; }
        /// <summary>
        /// Gets or sets the main body.
        /// </summary>
        /// <value>
        /// The main body.
        /// </value>
        [DataType(DataType.Html)]
        [Display(Name = "Text")]
        public virtual string MainBody { get; set; }
    }
}