using System;
using System.Data.Services.Common;

using NAd.Querying.Core.Persistency.NHibernate;

namespace NAd.Querying.Core.Domain
{
    /// <summary>
    /// Represents an entity as defined in Domain Driven Design which primary key is a long.
    /// </summary>
    [DataServiceKey(DatabaseConstants.IdentityColumn)]
    public abstract class Entity : IEntity
    {
        public virtual Guid Id { get; set; }

        object IEntity.Id
        {
            get { return Id; }
        }
    }
}