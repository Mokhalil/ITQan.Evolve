using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernal.Infrastructure.Domain.Specification;

namespace SharedKernal.Infrastructure.Domain
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        private TId _id;
        private IList<BusinessRule> _brokenRules = new List<BusinessRule>();
        private bool _idHasBeenSet = false;

        public Entity(TId id)
        {
            if (id.Equals(default(TId)))
            {
                throw new ArgumentException("The Id cannot be the type's default value", "id");
            }
            this.Id = id;
        }

        protected  Entity()
        { }

        public virtual TId Id
        {
            get { return _id; }
            set
            {
                if (_idHasBeenSet)
                    ThrowExceptionIfOverwrittingAnId();
                _id = value;
                _idHasBeenSet = true;
            }
        }



        protected abstract void Validate();

        public bool IsValid()
        {
            ClearCollectionOfBrokenRules();
            Validate();
            return _brokenRules.Count == 0;
        }

        private void ClearCollectionOfBrokenRules()
        {
            _brokenRules.Clear();
        }

        public IEnumerable<BusinessRule> GetBrokenRules()
        {
            return _brokenRules;
        }

        protected void AddBrokenRule(BusinessRule brokenRule)
        {
            _brokenRules.Add(brokenRule);
        }


        private void ThrowExceptionIfOverwrittingAnId()
        {
            throw new ApplicationException("You cannot change the id of an entity.");
        }

        public override bool Equals(object otherObject)
        {
            var entity = otherObject as Entity<TId>;
            if (entity != null)
            {
                return this.Equals(entity);
            }
            return base.Equals(otherObject);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public bool Equals(Entity<TId> other)
        {
            if (other != null)
            {
                this.Id.Equals(other.Id);
            }
            return false;

        }
    }
}
