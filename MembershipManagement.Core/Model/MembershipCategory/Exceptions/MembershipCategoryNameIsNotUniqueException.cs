using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipManagement.Core.Model.MembershipCategory.Exceptions
{
    public class MembershipCategoryNameIsNotUniqueException : ApplicationException
    {
        public MembershipCategoryNameIsNotUniqueException(string message)
            : base(message)
        { }
    }
}
