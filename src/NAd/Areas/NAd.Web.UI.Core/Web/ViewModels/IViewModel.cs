
using System.Collections.Generic;
using NAd.Framework.Persistence.Abstractions.Model;

namespace NAd.Web.UI.Core.ViewModels {
    
    /// <summary>
    /// Represents the view model
    /// </summary>
    public interface IViewModel<out T> {

        /// <summary>
        /// <see cref="DefaultViewModel{T}.CurrentModel"/>
        /// </summary>
        T CurrentModel { get; }
        
        /// <summary>
        /// Gets or sets the hierarchy.
        /// </summary>
        /// <value>
        /// The hierarchy.
        /// </value>
        IEnumerable<IPageModel> Hierarchy { get; set; }
    }
}