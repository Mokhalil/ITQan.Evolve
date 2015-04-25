using System;
using System.Text;
using MembershipManagement.Core.Exceptions;

namespace MembershipManagement.Core.Model.Benefits
{
    public class CirculationBuilder : BenefitBuilder
    {
        private CirculationBuilder()
        {
            Benefit = new Circulation();
        }

        public static CirculationBuilder Circulation()
        {
            return new CirculationBuilder();
        }

        public override Benefit Build()
        {
            if (!Benefit.IsValid())
            {
                var issues = new StringBuilder();
                foreach (var issue in Benefit.GetBrokenRules())
                {
                    issues.AppendLine(string.Format("{0} : {1}", issue.Property, issue.Rule));
                }
                throw new InvalidBenefitException(issues.ToString());
            }
            return (Circulation) Benefit;
        }

        #region Fleunt Interface Methods

        public CirculationBuilder ForCirculationType(CirculationType type)
        {
            ((Circulation)Benefit).SetCirculationType(type);
            return this;
        }

        public CirculationBuilder ForMembershipType(Guid id)
        {
            ((Circulation) Benefit).SetMembershipType(id);
            return this;
        }

        public CirculationBuilder CirculationsCanBeBorrowedFor(int days)
        {
            ((Circulation) Benefit).SetBorrowPeriod(days);
            return this;
        }

        public CirculationBuilder CanBeRenewed(int howManyTimes)
        {
            ((Circulation) Benefit).SetNumberOfRenewals(howManyTimes);
            return this;
        }

        public CirculationBuilder EachRenewalIs(int days)
        {
            ((Circulation) Benefit).SetRenewalPeriod(days);
            return this;
        }

        public CirculationBuilder ThenLockedFor(int days)
        {
            ((Circulation) Benefit).SetLockingPeriod(days);
            return this;
        }

        #endregion
    }
}