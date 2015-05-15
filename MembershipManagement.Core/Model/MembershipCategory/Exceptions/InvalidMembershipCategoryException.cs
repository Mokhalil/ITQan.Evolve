using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MembershipManagement.Core.Model.MembershipCategory.Exceptions
{
    public class InvalidMembershipCategoryException : ApplicationException
    {
        public InvalidMembershipCategoryException(string message)
            : base(message)
        {
        }
    }
}
