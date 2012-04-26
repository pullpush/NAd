﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using NAd.Framework.Persistence.Abstractions.Model;
using NAd.Web.UI.Core.Web.Routing;

namespace NAd.Web.UI.Core.Common {

    public static class Extensions {
        /// <summary>
        /// Creates the hierarchy.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="allItems">All items.</param>
        /// <param name="parentItem">The parent item.</param>
        /// <param name="depth">The depth.</param>
        /// <returns></returns>
        /*
        private static IEnumerable<HierarchyNode<TEntity>> CreateHierarchy<TEntity>(IEnumerable<TEntity> allItems, TEntity parentItem, int depth) where TEntity : class, IPageModel {

            if (parentItem == null)
                parentItem = allItems.Where(i => i.Parent == null).SingleOrDefault();

            if(parentItem == null) {
                yield break;
            }
            IEnumerable<TEntity> childs = allItems.Where(i => i.Parent != null && i.Parent.Id.Equals(parentItem.Id));

            if (childs.Count() > 0) {
                depth++;

                foreach (var item in childs)
                    yield return
                        new HierarchyNode<TEntity>()
                            {
                                Entity = item,
                                ChildNodes = CreateHierarchy(allItems, item, depth),
                                Depth = depth,
                                Expanded = allItems.Where(x => x.Parent != null && x.Parent.Id.Equals(item.Id)).Count() > 0
                            };
            }
        }
        */

        /// <summary>
        /// Ases the hierarchy.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="allItems">All items.</param>
        /// <returns></returns>
        /*
        public static IEnumerable<HierarchyNode<TEntity>> AsHierarchy<TEntity>(this IEnumerable<TEntity> allItems) where TEntity : class, IPageModel {
            return CreateHierarchy(allItems, default(TEntity), 0);
        }
        */

        /// <summary>
        /// Registers the page route.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="pathResolver">The path resolver.</param>
        /// <param name="virtualPathResolver">The virtual path resolver.</param>
        /// <returns></returns>
        public static RouteCollection RegisterPageRoute(this RouteCollection routes, IPathResolver pathResolver, IVirtualPathResolver virtualPathResolver) {
            var pageRoute = new PageRoute(pathResolver, virtualPathResolver);
            routes.Add("PageRoute", pageRoute);
            return routes;
        }

        /// <summary>
        /// Used for adding a page model to the RouteData object's DataTokens
        /// </summary>
        /// <param name="data"></param>
        /// <param name="controllerName"></param>
        /// <param name="actionName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static RouteData ApplyCurrentModel(this RouteData data, string controllerName, string actionName, dynamic model) {
            data.Values[PageRoute.ControllerKey] = controllerName.Replace("Controller","");
            data.Values[PageRoute.ActionKey] = actionName;
            data.Values[PageRoute.ModelKey] = model;
            return data;
        }

        /// <summary>
        /// Returns the current model of the current request
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T GetCurrentModel<T>(this RouteData data) {
            return (T)data.Values[PageRoute.ModelKey];
        }

        /// <summary>
        /// Adds the query param.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string AddQueryParam(this string source, string key, string value) {
            string delim;
            if ((source == null) || !source.Contains("?")) {
                delim = "?";
            } else if (source.EndsWith("?") || source.EndsWith("&")) {
                delim = string.Empty;
            } else {
                delim = "&";
            }
            return source + delim + HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(value);
        }

        /// <summary>
        /// Formats the size of the file.
        /// </summary>
        /// <param name="fileSize">Size of the file.</param>
        /// <returns></returns>
        public static string FormatFileSize(this long fileSize) {
            string[] suffix = { "bytes", "KB", "MB", "GB" };
            long j = 0;

            while (fileSize > 1024 && j < 4) {
                fileSize = fileSize / 1024;
                j++;
            }
            return (fileSize + " " + suffix[j]);
        }

        /// <summary>
        /// Actions the link.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, IPageModel model) {
            return htmlHelper.ActionLink(model.Metadata.Name, model);
        }

        /// <summary>
        /// Actions the link.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, IPageModel model) {
            return htmlHelper.ActionLink(linkText, "index", new { model });
        }

        /// <summary>
        /// Actions the specified URL helper.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static string Action(this UrlHelper urlHelper, IPageModel model) {
            return urlHelper.Action("index", new {model});
        }

        /// <summary>
        /// Actions the specified URL helper.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static string Action(this UrlHelper urlHelper,string actionName, IPageModel model) {
            return urlHelper.Action(actionName, new { model });
        }

        /// <summary>
        /// Get the attribute of a specific type, returns null if not exists
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this Type type) where T : Attribute {
            T attribute = null;

            var attributes = type.GetCustomAttributes(true);
            foreach (var attributeInType in attributes) {
                if (typeof(T).IsAssignableFrom(attributeInType.GetType()))
                    attribute = (T)attributeInType;
            }

            return attribute;
        }

        /// <summary>
        /// Radioes the button for select list.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="listOfValues">The list of values.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonForSelectList<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> listOfValues) {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var sb = new StringBuilder();
            if (listOfValues != null) {
                foreach (SelectListItem item in listOfValues) {
                    var id = string.Format(
                        "{0}_{1}",
                        metaData.PropertyName,
                        item.Value
                    );

                    var radio = htmlHelper.RadioButtonFor(expression, item.Value, new { id }).ToHtmlString();
                    sb.AppendFormat(
                        "<label for=\"{0}\">{2} {1}</label>",
                        id,
                        HttpUtility.HtmlEncode(item.Text),
                        radio
                    );
                }
            }

            return MvcHtmlString.Create(sb.ToString());
        }

        private const string DateFormat = "{0} {1} {2}";
        public static string FormatDate(this DateTime? dateTime) {
            var difference = DateTime.Now.Subtract((DateTime) dateTime);

            if (difference.Days >= 1) {
                if (difference.Days == 1) {
                    return "yesterday";
                }
                return dateTime.Value.ToShortDateString();
            }
            if (difference.Hours == 0) {
                if (difference.Minutes == 0) {
                    return "just now";
                }
                return string.Format(DateFormat, difference.Minutes, difference.Minutes == 1 ? "minute" : "minutes", "ago");
            }
            return string.Format(DateFormat, difference.Hours, difference.Hours == 1 ? "hour" : "hours", "ago");
        }


        public static string ContentArea(this UrlHelper url, string path) {
            var area = url.RequestContext.RouteData.DataTokens["area"];

            if (area != null) {
                if (!string.IsNullOrEmpty(area.ToString()))
                    area = "Areas/" + area;

                // Simple checks for '~/' and '/' at the
                // beginning of the path.
                if (path.StartsWith("~/"))
                    path = path.Remove(0, 2);

                if (path.StartsWith("/"))
                    path = path.Remove(0, 1);

                path = path.Replace("../", string.Empty);

                return VirtualPathUtility.ToAbsolute("~/" + area + "/" + path).ToLower();
            }

            return string.Empty;
        }
    }
}