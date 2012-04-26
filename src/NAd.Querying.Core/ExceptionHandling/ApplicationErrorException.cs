using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NAd.Querying.Core.ExceptionHandling
{
    /// <summary>
    ///   Represents a technical application exception which display message should be resolved through its <see cref = "Error" /> property.
    /// </summary>
    public class ApplicationErrorException : Exception, IEnumerable
    {
        private readonly Dictionary<string, object> parameters = new Dictionary<string, object>();

        /// <summary>
        ///   Initializes a new instance of the <see cref = "ApplicationErrorException" /> class.
        /// </summary>
        /// <param name = "error">
        ///   The <see cref = "Error" /> that uniquely identifies this exception.
        /// </param>
        /// <param name = "parameters">
        ///   A collection of key-value pairs representing the parameters under which the error occurred.
        /// </param>
        public ApplicationErrorException(Error error, IDictionary<string, object> parameters)
            : this(error, null, parameters)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "ApplicationErrorException" /> class.
        /// </summary>
        /// <param name = "error">
        ///   The <see cref = "Error" /> that uniquely identifies this exception.
        /// </param>
        public ApplicationErrorException(Error error)
            : this(error, null, new Dictionary<string, object>())
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "ApplicationErrorException" /> class.
        /// </summary>
        /// <param name = "error">The <see cref = "Error" /> that describes the exception.</param>
        /// <param name = "innerException">The inner exception.</param>
        /// <param name = "parameters">
        ///   A collection of key-value pairs representing the parameters under which the error occurred.
        /// </param>
        public ApplicationErrorException(Error error, Exception innerException, IDictionary<string, object> parameters) 
            : base(Format(error, parameters), innerException)
        {
            Error = error;
            
            this.parameters = new Dictionary<string, object>(parameters);
        }

        /// <summary>
        ///   The error that identifies the reason for this exception.
        /// </summary>
        public Error Error { get; set; }

        /// <summary>
        ///   Gets a collection of key-value pairs representing the parameters under which the error occurred.
        /// </summary>
        public IDictionary<string, object> Parameters
        {
            get { return parameters; }
        }

        /// <summary>
        ///   Gets a message that describes the current exception.
        /// </summary>
        /// <value></value>
        /// <returns>The error message that explains the reason for the exception, or an empty string("").</returns>
        private static string Format(Error error, IDictionary<string, object> dictionary)
        {
            string message = error.Code;

            if (dictionary.Any())
            {
                message += " { " + dictionary.Aggregate(message,
                    (current, keyValuePair) => current + (keyValuePair.Key + "=" + keyValuePair.Value)) + " } ";
            }

            return message;
        }

        /// <summary>
        /// Adds the key and a value to the <see cref="Parameters"/>.
        /// </summary>
        public void Add(string key, object value)
        {
            Parameters.Add(key, value);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="Parameters"/>.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return Parameters.GetEnumerator();
        }
    }
}
