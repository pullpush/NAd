using System;
using System.Collections;
using System.Collections.Generic;
using NAd.Framework.Persistence.Abstractions;

namespace NAd.Framework.Domain
{
    public class Classified : VersionedEntity<Guid>
    {
        //private readonly IDictionary _attributes = new Hashtable();

        //public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual List<AttributeValue<string>> StringAttributes { get; set; }

        public virtual List<AttributeValue<int>> IntegerAttributes { get; set; }

        //public virtual dynamic Attributes
        //{
        //    get { return new HashtableDynamicObject(_attributes); }
        //}
    }
}
