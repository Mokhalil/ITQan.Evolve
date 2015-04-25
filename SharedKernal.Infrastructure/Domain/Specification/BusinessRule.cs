using System;

namespace SharedKernal.Infrastructure.Domain.Specification
{
    public class BusinessRule
    {
        public string Rule { get; protected set; }

        public string Property { get; protected set; }

        private BusinessRule(string rule, string property)
        {
            if (string.IsNullOrEmpty(rule))
                throw new ArgumentException("Rule");

            if (string.IsNullOrEmpty(property))
                throw new ArgumentException("Property");

            Rule = rule;
            Property = property;
        }

        public static BusinessRule CreateRule(string rule, string property)
        {
            return new BusinessRule(rule, property);
        }
    }
}
