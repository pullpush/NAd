
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Web.Mvc;

namespace NAd.Web.UI.Core.Web.Mvc
{
    public class ControllerMapper : IControllerMapper {

        static readonly ConcurrentDictionary<Type, string> ControllerMap = new ConcurrentDictionary<Type, string>();
        static readonly ConcurrentDictionary<string, string[]> ControllerActionMap = new ConcurrentDictionary<string, string[]>();

        /// <summary>
        /// Gets the name of the controller.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public string GetControllerName(Type type) {
            
            string name;
            ControllerMap.TryGetValue(type, out name);
            return name;

        }

        /// <summary>
        /// Controllers the has action.
        /// </summary>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <returns></returns>
        public bool ControllerHasAction(string controllerName, string actionName) {
            if (!ControllerActionMap.ContainsKey(controllerName))
                return false;

            foreach (var action in ControllerActionMap[controllerName]) {
                if (String.Equals(action, actionName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerMapper"/> class.
        /// </summary>
        public ControllerMapper() {

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies) {
                foreach (var type in assembly.GetTypes()) {
                    if (!type.IsClass) {
                        continue;
                    }
                    if (type.IsSubclassOf(typeof(Controller))) {
                        ControllerMap.TryAdd(type, type.Name);
                        var methodNames = type.GetMethods().Select(x => x.Name).ToArray();
                        ControllerActionMap.TryAdd(type.Name,methodNames);
                    }
                }
            }

        }

    }
}