using System;
using System.Collections.Generic;
using System.Linq;

namespace NAd.Common
{
    public class ViolationCollector
    {
        private readonly List<Violation> violations = new List<Violation>();

        public void Add(Rule violatedRule)
        {
            violations.Add(new Violation(violatedRule));
        }

        public void Add(Violation violation)
        {
            violations.Add(violation);
        }

        public void AddRange(IEnumerable<Violation> violations)
        {
            this.violations.AddRange(violations);
        }

        public void ThrowIfAny()
        {
            if (violations.Any())
            {
                throw new RuleViolationException(violations);
            }
        }
    }
}