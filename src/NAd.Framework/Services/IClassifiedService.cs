using System;
using System.Collections.Generic;
using NAd.Framework.Domain;

namespace NAd.Framework.Services
{
    public interface IClassifiedService
    {
        IEnumerable<Classified> GetClassifieds(string partialName, string partialDescription);
        Classified Get(Guid id);
        Classified GetByUrl(string url);
        void Save(Classified classified);
        bool CheckNotUniqueClassifiedName(string name);
    }
}
