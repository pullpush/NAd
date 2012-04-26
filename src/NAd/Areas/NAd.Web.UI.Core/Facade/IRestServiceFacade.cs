using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NAd.Web.UI.Core.Facade
{
    public interface IRestServiceFacade<out T> where T : class
    {
        //T SingleOrDefault<T>(Expression<Func<T, bool>> predicate);
        T GetById(string requestMessage, string id);
        //IEnumerable<T> List<T>(Expression<Func<T, bool>> predicate);
    }
}