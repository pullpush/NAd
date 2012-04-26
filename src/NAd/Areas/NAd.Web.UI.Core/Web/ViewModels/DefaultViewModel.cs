
using System.Collections.Generic;
using NAd.Framework.Persistence.Abstractions.Model;

namespace NAd.Web.UI.Core.ViewModels
{
    /// <summary>
    /// The default view model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DefaultViewModel<T> : IViewModel<T> where T : IPageModel {

        /// <summary>
        /// Gets the current model.
        /// </summary>
        public virtual T CurrentModel { get; set; }

        /// <summary>
        /// Gets the structure info.
        /// </summary>
        public virtual IEnumerable<IPageModel> Hierarchy { get; set; }
    }
}