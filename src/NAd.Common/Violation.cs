using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NAd.Common
{
    /// <summary>
    ///   Represents a single rule violation along with some parameters that can be used for
    /// </summary>
    public class Violation : IEnumerable<String>
    {
        public Violation(Rule rule)
            : this(rule, new Dictionary<string, object>())
        {
        }

        public Violation(Rule rule, IDictionary<string, object> parameters)
        {
            Rule = rule;
            Parameters = parameters;
        }

        /// <summary>
        ///   Gets the rule that was violated.
        /// </summary>
        public Rule Rule { get; private set; }

        /// <summary>
        ///   Gets a collection of key-value pairs representing the parameters under which the violation occurred.
        /// </summary>
        public IDictionary<string, object> Parameters { get; private set; }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return Parameters.Keys.GetEnumerator();
        }

        /// <summary>
        ///   Returns a <see cref = "System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///   A <see cref = "System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string message = Rule.Code;

            if (Parameters.Any())
            {
                message += " { " + Parameters.Aggregate(message,
                    (current, keyValuePair) => current + (keyValuePair.Key + "=" + keyValuePair.Value)) + " } ";
            }

            return message;
        }

        /// <summary>
        /// Adds the specified key-value combination to the <see cref="Parameters"/> property.
        /// </summary>
        public void Add(string key, object value)
        {
            Parameters[key] = value;
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
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