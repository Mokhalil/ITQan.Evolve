using System;

namespace MembershipManagement.Core.Model.Benefits
{
    public class NullBenefit : Benefit
    {
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}