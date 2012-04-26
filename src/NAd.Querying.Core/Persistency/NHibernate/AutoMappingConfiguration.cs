using System;
using System.Collections.Generic;

using NAd.Querying.Core.Domain;
using NAd.Querying.Core.Persistency.Common;

using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Mapping;

namespace NAd.Querying.Core.Persistency.NHibernate
{
    internal class AutoMappingConfiguration : DefaultAutomappingConfiguration
    {
        /// <summary>
        ///     Determines whether a type should be auto-mapped.
        ///     Override to restrict which types are mapped in your domain.
        /// </summary>
        /// <remarks>
        ///     You normally want to override this method and restrict via something known, like
        ///     Namespace.
        /// </remarks>
        /// <example>
        ///     return type.Namespace.EndsWith("Domain");
        /// </example>
        /// <param name = "type">Type to map</param>
        /// <returns>
        ///     Should map type
        /// </returns>
        public override bool ShouldMap(Type type)
        {
            return typeof(IEntity).IsAssignableFrom(type);
        }

        /// <summary>
        ///     Specifies that a particular type should be mapped as a component rather than
        ///     an entity.
        /// </summary>
        /// <param name = "type">Type</param>
        /// <returns>
        ///     Type is a component?
        /// </returns>
        public override bool IsComponent(Type type)
        {
            return typeof(IPersistAsComponent).IsAssignableFrom(type);
        }

        /// <summary>
        ///     Gets the column prefix for a component.
        /// </summary>
        /// <param name = "member">Member defining the component</param>
        /// <returns>
        ///     Component column prefix
        /// </returns>
        public override string GetComponentColumnPrefix(Member member)
        {
            return member.Name + DatabaseConstants.ComponentColumnPrefix;
        }
    }
}
