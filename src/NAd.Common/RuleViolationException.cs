using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//using FakeItEasy;

namespace NAd.Common
{
    /// <summary>
    /// Represents a functional error such as a business rule validation or another functional error which display message
    /// should be resolved through its <see cref="Rule"/> property.
    /// </summary>
    [Serializable]
    public class RuleViolationException : Exception, IEnumerable
    {
        private readonly List<Violation> violations = new List<Violation>();

        /// <summary>
        /// Gets the details on the specific rules that were violated.
        /// </summary>
        public IEnumerable<Violation> Violations
        {
            get { return violations; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleViolationException"/> class for a single rule violation.
        /// </summary>
        /// <param name="rule">The rule that was violated.</param>
        /// <param name="parameters">Gets a collection of key-value pairs representing the parameters under which the violation occurred..</param>
        public RuleViolationException(Rule rule, IDictionary<string, object> parameters)
            : this(new Violation(rule, parameters).ToEnumerable())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleViolationException"/> class for a single rule violation.
        /// </summary>
        /// <param name="rule">The rule that was violated.</param>
        public RuleViolationException(Rule rule)
            : this(new Violation(rule, new Dictionary<string, object>()).ToEnumerable())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleViolationException"/> class for one or more rule violation.
        /// </summary>
        public RuleViolationException(IEnumerable<Violation> violations)
            : base(string.Join(", ", violations))
        {
            this.violations.AddRange(violations);
        }

        /// <summary>
        /// Adds a named parameter to the first violation of this exception object.
        /// </summary>
        public void Add(string key, string value)
        {
            Violations.First().Parameters.Add(key, value);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="Violations"/>.
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return Violations.GetEnumerator();
        }
    }
}