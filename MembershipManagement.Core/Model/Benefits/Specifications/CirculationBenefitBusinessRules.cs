using SharedKernal.Infrastructure.Domain.Specification;

namespace MembershipManagement.Core.Model.Benefits.Specifications
{
    internal static class CirculationBenefitBusinessRules
    {
        public static readonly BusinessRule BorrowPeriodCannotBeZero;
        public static readonly BusinessRule RenewalPeriodCannotBeZero;
        public static readonly BusinessRule LockingPeriodCannotBeZero;
        public static readonly BusinessRule RenewalPeriodCannotBeGreaterThanBorrowPeriod;
        public static readonly BusinessRule BenefitMustBeAssignedToBenefit;
        public static readonly BusinessRule CirculationTypeMustBeValid;

        static CirculationBenefitBusinessRules()
        {
            BenefitMustBeAssignedToBenefit = BusinessRule.CreateRule("Benefit Must Be Assigned To A Membership Type", "Membership Type Id");
            RenewalPeriodCannotBeGreaterThanBorrowPeriod = BusinessRule.CreateRule("Renew Period Cannot be Greater than Borrow Period","RenewPeriod");
            LockingPeriodCannotBeZero = BusinessRule.CreateRule("Locking Period Cannot be 0 days",
                "RenewPeriod");
            RenewalPeriodCannotBeZero = BusinessRule.CreateRule("Renew Period Cannot be 0 days",
                "RenewPeriod");
            BorrowPeriodCannotBeZero = BusinessRule.CreateRule("Borrow Period Cannot be 0 days",
                "BorrowPeriod");
            CirculationTypeMustBeValid = BusinessRule.CreateRule("Circulation Type must cotain valid value","Circulation Type");
        }
    }
}
