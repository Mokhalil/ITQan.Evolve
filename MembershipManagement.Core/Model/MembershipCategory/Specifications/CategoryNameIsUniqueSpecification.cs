using System;
using SharedKernal.Infrastructure.Domain.Specification;

namespace MembershipManagement.Core.Model.MembershipCategory.Specifications
{
    public class HasAlreadyBeenCreatedBeforeSpecification:ISpecification<Core.MembershipCategory>
    {
        public bool IsSatisfiedBy(Core.MembershipCategory candidate)
        {
            throw new NotImplementedException();
        }
    }
}
