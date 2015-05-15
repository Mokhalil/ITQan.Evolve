using SharedKernal.Infrastructure.Domain;

namespace MembershipManagement.Core.Model.Benefits
{
    public abstract class Benefit : Entity<int>
    {
        public bool IsActive { get; protected set; }

        public virtual void Activate()
        {
            IsActive = true;
        }

        public virtual void Suspend()
        {
            IsActive = false;
        }       
    }
}