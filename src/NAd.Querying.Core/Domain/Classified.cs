using System;
using System.Collections;

namespace NAd.Querying.Core.Domain
{
    public class Classified : VersionedEntity
    {
        private readonly IDictionary _attributes = new Hashtable();

        //public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreatedDate { get; set; }


        public virtual dynamic Attributes
        {
            get { return new HashtableDynamicObject(_attributes); }
        }
    }
}
