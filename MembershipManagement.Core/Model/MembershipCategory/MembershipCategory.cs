using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MembershipManagement.Core.Model;
using MembershipManagement.Core.Model.Benefits;
using SharedKernal.Infrastructure.Domain;

namespace MembershipManagement.Core
{
    public class MembershipCategory : Entity<Guid>,AggregateRoot
    {
        public List<Benefit> Benefits
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
