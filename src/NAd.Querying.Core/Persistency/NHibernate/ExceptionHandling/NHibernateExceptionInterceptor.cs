
using System;
using System.Collections.Generic;

using Castle.DynamicProxy;

using NHibernate.Exceptions;

namespace NAd.Querying.Core.Persistency.NHibernate.ExceptionHandling
{
    /// <summary>
    /// Unity interception call handler that is used to intercept exceptions thrown by NHibernate and pass them
    /// to one or more implementations of <see cref="INHibernateExceptionPolicy"/>.
    /// </summary>
    public class NHibernateExceptionInterceptor : IInterceptor
    {
        private readonly IEnumerable<INHibernateExceptionPolicy> policies;

        public NHibernateExceptionInterceptor(IEnumerable<INHibernateExceptionPolicy> policies)
        {
            this.policies = policies;
        }

        /// <summary>
        ///   Order in which the handler will be executed
        /// </summary>
        public int Order { get; set; }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                if (exception is GenericADOException)
                {
                    foreach (var policy in policies)
                    {
                        exception = policy.Process(exception);
                    }

                    throw exception;
                }
                else
                {
                    throw;
                }

            }
        }
    }
}