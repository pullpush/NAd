
using System;
using System.Collections.Generic;

using NAd.Querying.Core.DataAccess;

namespace NAd.UI.Services
{
    public interface IQueryAgent
    {
        void FindRecipes(string partialName, string partialDescription, Action<IEnumerable<Classified>> callback);
    }
}