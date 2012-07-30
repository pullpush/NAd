
using System.Web;
using NAd.Framework;
using NAd.Framework.Persistence.Abstractions.Model;
using NAd.Web.UI.Core.Common;
using NAd.Web.UI.Core.Facade;
using NAd.Web.UI.Core.Web.Mvc;
//using Autofac;

namespace NAd.Web.UI.Core.Web.Routing {

    public class PathResolver : IPathResolver {
        private readonly IPathData _pathData;
        private IPageServiceFacade _pageService;
        private readonly IControllerMapper _controllerMapper;
        //private readonly IContainer _container;
        private IPageModel _pageModel;
        private string _controllerName;

        /// <summary>
        /// Resolves the path.
        /// </summary>
        /// <param name="virtualUrl">The virtual URL.</param>
        /// <returns></returns>
        public IPathData ResolvePath(string virtualUrl) {

            // Set the default action to index
            _pathData.Action = PageRoute.DefaultAction;

            // Get an up to date page repository
            //_pageService = _container.Resolve<IPageServiceFacade>();

            
            // The requested url is for the start page with no action
            if (string.IsNullOrEmpty(virtualUrl) || string.Equals(virtualUrl, "/") || virtualUrl.StartsWith("classifieds"))
            {
                //_pageModel = _pageService.SingleOrDefault<IPageModel>(x => x.Parent == null);
                //_pageModel = _pageService.GetPageByUrl(null);
                //This is a site home page
                _pageModel = null; // new Home();

            } else {
                // Remove the trailing slash
                virtualUrl = VirtualPathUtility.RemoveTrailingSlash(virtualUrl);
                // The normal beahaviour should be to load the page based on the url
                //_pageModel = _pageService.GetPageByUrl<IPageModel>(virtualUrl);
                _pageModel = _pageService.GetPageByUrl(virtualUrl);
                // Try to load the page without the last segment of the url and set the last segment as action))
                if (_pageModel == null && virtualUrl.LastIndexOf("/") > 0) {
                    var index = virtualUrl.LastIndexOf("/");
                    var action = virtualUrl.Substring(index, virtualUrl.Length - index).Trim(new[] { '/' });
                    virtualUrl = virtualUrl.Substring(0, index).TrimStart(new[] { '/' });
                    //_pageModel = _pageService.GetPageByUrl<IPageModel>(virtualUrl);
                    _pageModel = _pageService.GetPageByUrl(virtualUrl);
                    _pathData.Action = action;
                }
                // If the page model still is empty, let's try to resolve if the start page has an action named (virtualUrl)
                if (_pageModel == null) {
                    //_pageModel = _pageService.SingleOrDefault<IPageModel>(x => x.Parent == null);
                    _pageModel = _pageService.GetPageByUrl(null);
                    var pageModelAttribute = _pageModel.GetType().GetAttribute<PageModelAttribute>();
                    _controllerName = _controllerMapper.GetControllerName(pageModelAttribute.ControllerType);
                    var action = virtualUrl.TrimStart(new[] { '/' });
                    if (!_controllerMapper.ControllerHasAction(_controllerName, action)) {
                        return null;
                    }
                    _pathData.Action = action;
                }
            }
            

            if (_pageModel == null) {
                return null;
            }

            var controllerType = _pageModel.GetType().GetAttribute<PageModelAttribute>().ControllerType;
            _pathData.Controller = _controllerMapper.GetControllerName(controllerType);
            _pathData.CurrentPageModel = _pageModel;
            return _pathData;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathResolver"/> class.
        /// </summary>
        /// <param name="pathData">The path data.</param>
        /// <param name="pageService">The page service facade.</param>
        /// <param name="controllerMapper">The controller mapper.</param>
        /// <param name="container">The container.</param>
        public PathResolver(IPathData pathData, IPageServiceFacade pageService, IControllerMapper controllerMapper) //, IContainer container
        {
            _pathData = pathData;
            _pageService = pageService;
            _controllerMapper = controllerMapper;
            //_container = container;
        }
    }
}