using System;

namespace NAd.Querying.Core.Persistency.NHibernate.ExceptionHandling
{
    /// <summary>
    /// Represents a policy that can handle exceptions while executing operations through
    /// an NHibernate session that are intercepted through <see cref="NHibernateExceptionInterceptor"/>.   
    /// </summary>
    public interface INHibernateExceptionPolicy
    {
        /// <summary>
        /// Processes the NHibernate exception and returns a possibily wrapping exception.
        /// </summary>
        Exception Process(Exception exception);
    }
}