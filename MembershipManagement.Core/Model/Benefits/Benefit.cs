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

        public static Benefit CreateBenefit(BenefitType type)
        {
            switch (type)
            {
                case BenefitType.Circulation:
                    return new Circulation();

                case BenefitType.Facility:
                    return new Facilities();

                case BenefitType.TimedFacility:
                    return new TimedFacility();

                default:
                    return new NullBenefit();
            }
        }
    }
}