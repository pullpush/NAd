using System;
using System.Collections.Generic;

using NAd.Querying.Core.Domain;

namespace NAd.Querying.Core.Services
{
    public interface IClassifiedService
    {
        IEnumerable<Classified> GetClassifieds(string partialName, string partialDescription);
        Classified GetById(Guid id);
        void Save(Classified classified);
        bool CheckNotUniqueClassifiedName(string name);
    }
}
