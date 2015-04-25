using System;
using MembershipManagement.Core.Model.Benefits.Specifications;

namespace MembershipManagement.Core.Model.Benefits
{
    public class Circulation : Benefit
    {
        public int BorrowPeriod { get; protected set; }
        public int NumberOfRenewals { get; protected set; }
        public int RenewalPeriod { get; protected set; }
        public int LockingPeriod { get; protected set; }
        public Guid MembershipTypeId { get; protected set; }
        public CirculationType Type { get; protected set; }
        //public bool  { get; set; }


        public void SetCirculationType(CirculationType type)
        {
            Type = type;
        }

        public void SetMembershipType(Guid id)
        {
            MembershipTypeId = id;
        }

        public void SetBorrowPeriod(int days)
        {
            BorrowPeriod = days;
        }

        public void SetNumberOfRenewals(int howManyTimes)
        {
            NumberOfRenewals = howManyTimes;
        }

        public void SetRenewalPeriod(int days)
        {
            RenewalPeriod = days;
        }

        public void SetLockingPeriod(int days)
        {
            LockingPeriod = days;
        }

        protected override void Validate()
        {
            if (MembershipTypeId == default(Guid))
                AddBrokenRule(CirculationBenefitBusinessRules.BenefitMustBeAssignedToBenefit);

            if (BorrowPeriod == default(int))
                AddBrokenRule(CirculationBenefitBusinessRules.BorrowPeriodCannotBeZero);

            if (RenewalPeriod == default(int))
                AddBrokenRule(CirculationBenefitBusinessRules.RenewalPeriodCannotBeZero);

            if (RenewalPeriod > BorrowPeriod)
                AddBrokenRule(CirculationBenefitBusinessRules.RenewalPeriodCannotBeGreaterThanBorrowPeriod);

            if (LockingPeriod == default(int))
                AddBrokenRule(CirculationBenefitBusinessRules.LockingPeriodCannotBeZero);

            if (!Enum.IsDefined(typeof (CirculationType), Type) || Type==CirculationType.NoValue)
                AddBrokenRule(CirculationBenefitBusinessRules.CirculationTypeMustBeValid);
        }
    }
}