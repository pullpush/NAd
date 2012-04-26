using System;
using System.Data.Services.Common;

namespace NAd.Querying.Core.DataAccess
{
    [DataServiceKey("Id")]
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }
    }
}
