using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedKernal.Infrastructure.Domain.Specification;

namespace MembershipManagement.Core
{
    public class MembershipDeletionSpecification: ISpecification<MembershipCategory>
    {
        public bool IsSatisfiedBy(MembershipCategory candidate)
        {
            throw new NotImplementedException();
        }
    }
}
