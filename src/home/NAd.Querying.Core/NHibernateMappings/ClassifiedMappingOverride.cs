
using System;
using System.Linq;

using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace NAd.Querying.Core.DataAccess
{
    public class ClassifiedMappingOverride : IAutoMappingOverride<Classified>
    {
        public void Override(AutoMapping<Classified> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
        }
    }
}
