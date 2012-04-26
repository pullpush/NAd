using System;

namespace NAd.Querying.Core.DataAccess
{
    public class Classified : Entity
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreatedDate { get; set; }
    }
}
