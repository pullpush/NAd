
using NAd.Framework.Persistence.Abstractions.Model;

namespace NAd.Web.UI.Core.Web.Routing
{
    public interface IPathData {
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        string Action { get; set; }
        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        /// <value>
        /// The controller.
        /// </value>
        string Controller { get; set; }
        /// <summary>
        /// Gets or sets the current page model.
        /// </summary>
        /// <value>
        /// The current page model.
        /// </value>
        IPageModel CurrentPageModel { get; set; }
    }
}