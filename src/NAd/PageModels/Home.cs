
using System.ComponentModel.DataAnnotations;
using NAd.Framework;
using NAd.UI.Controllers;

namespace NAd.UI.PageModels
{
    /// <summary>
    /// 
    /// </summary>
    [PageModel(Name = "Home page", ControllerType = typeof(HomeController))]
    public class Home : BaseEditorial {
        
        /// <summary>
        /// Gets or sets the main intro.
        /// </summary>
        /// <value>
        /// The main intro.
        /// </value>
        [DataType(DataType.MultilineText)]
        [Display(Name = "Introduction",Order = 200)]
        public string MainIntro { get; set; }
      
        /// <summary>
        /// Gets or sets the quote link.
        /// </summary>
        /// <value>
        /// The quote link.
        /// </value>
        //[Display(Name = "Get a quote link", Order = 300)]
        //public ModelReference QuoteLink { get; set; }
        
        /// <summary>
        /// Gets or sets the main body.
        /// </summary>
        /// <value>
        /// The main body.
        /// </value>
        [Display(Name = "Why", Order = 400)]
        public override string MainBody {
            get { 
                return base.MainBody;
            }
            set {
                base.MainBody = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the portfolio.
        /// </summary>
        /// <value>
        /// The portfolio.
        /// </value>
        [Display(Order = 500)]
        [DataType(DataType.Html)]
        public string Portfolio { get; set; }
        /// <summary>
        /// Gets or sets the weblog.
        /// </summary>
        /// <value>
        /// The weblog.
        /// </value>
        [Display(Order = 600)]
        [DataType(DataType.Html)]
        
        public string Weblog { get; set; }
        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        /// <value>
        /// The contact.
        /// </value>
        [Display(Order = 700)]
        [DataType(DataType.Html)]
        public string Contact { get; set; }
        
        /// <summary>
        /// Gets or sets the about us.
        /// </summary>
        /// <value>
        /// The about us.
        /// </value>
        [Display(Name = "About us",Order = 800)]
        [DataType(DataType.Html)]
        public string AboutUs { get; set; }
    }
}