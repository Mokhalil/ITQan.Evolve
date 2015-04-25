using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SharedKernal.Infrastructure.Domain.Exceptions;
using SharedKernal.Infrastructure.Domain.Specification;


//Jimmy Bogard Implementation of the ValueObject Base http://grabbagoft.blogspot.co.uk/2007/06/generic-value-object-equality.html


namespace SharedKernal.Infrastructure.Domain
{

    public abstract class ValueObject<T> : IEquatable<T>
   where T : ValueObject<T>, IValidator<T>
    {
        private List<BusinessRule> _brokenBusinessRules = new List<BusinessRule>();

        protected abstract void Validate();

        public bool IsValid()
        {
            ClearBrokenRules();
            Validate();
            return _brokenBusinessRules.Count == 0;
        }

        private void ClearBrokenRules()
        {
            _brokenBusinessRules.Clear();
        }

        public virtual IEnumerable<BusinessRule> GetBrokenBusinessRules()
        {
             return _brokenBusinessRules;
        }

        protected void AddBrokenRule(BusinessRule rule)
        {
            _brokenBusinessRules.Add(rule);
        }

       //This function will be called from the subclass constructor
        public void ThrowExcepionIfInvalid()
        {
            ClearBrokenRules();
            Validate();
            if (_brokenBusinessRules.Count > 0)
            {
                var issues = new StringBuilder();
                foreach (var businessRule in _brokenBusinessRules)
                {
                    issues.AppendLine(businessRule.Rule);
                }

                throw new ValueObjectIsInvalidException(issues.ToString());
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            T other = obj as T;

            return Equals(other);
        }

        public override int GetHashCode()
        {
            IEnumerable<FieldInfo> fields = GetFields();

            int startValue = 17;
            int multiplier = 59;

            int hashCode = startValue;

            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(this);

                if (value != null)
                    hashCode = hashCode * multiplier + value.GetHashCode();
            }

            return hashCode;
        }

        public virtual bool Equals(T other)
        {
            if (other == null)
                return false;

            Type t = GetType();
            Type otherType = other.GetType();

            if (t != otherType)
                return false;

            FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (FieldInfo field in fields)
            {
                object value1 = field.GetValue(other);
                object value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                        return false;
                }
                else if (!value1.Equals(value2))
                    return false;
            }

            return true;
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            Type t = GetType();

            List<FieldInfo> fields = new List<FieldInfo>();

            while (t != typeof(object))
            {
                fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));

                t = t.BaseType;
            }

            return fields;
        }

        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
        {
            return !(x == y);
        }
    }
}
