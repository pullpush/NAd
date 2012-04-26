﻿
using System;
using NAd.Common;


namespace NAd.Framework.Persistence.NHibernate.ExceptionHandling
{
    public class NAdExceptionPolicy : INHibernateExceptionPolicy
    {
        /// <summary>
        /// Processes the NHibernate exception and returns a possibily wrapping exception.
        /// </summary>
        public Exception Process(Exception exception)
        {
            var applicationErrorException = exception as ApplicationErrorException;
            
            //if ((applicationErrorException != null) &&
            //    (applicationErrorException.Error == ServiceError.NameCodeOrNumberIsNotUnique) &&
            //        (applicationErrorException.Parameters["EntityType"].Equals(typeof(Recipe))))
            //{
            //    exception = new RuleViolationException(NAdRule.RecipeTitleMustBeUnique);
            //}

            //if ((applicationErrorException != null) &&
            //    (applicationErrorException.Error == ServiceError.DataSizeWasExceeded) &&
            //    (applicationErrorException.Parameters["EntityType"].Equals(typeof(Recipe))))
            //{
            //    exception = new RuleViolationException(NAdRule.RecipeTitleMustBeShort);
            //}
            
            //if ((applicationErrorException != null) &&
            //    (applicationErrorException.Error == ServiceError.RecordIsUsedByAnotherRecord) &&
            //    (applicationErrorException.Parameters["EntityType"].Equals(typeof(Product))))
            //{
            //    exception = new RuleViolationException(NAdRule.ProductCannotBeRemovedIfStillUsed);
            //}

            return exception;
        }
    }
}