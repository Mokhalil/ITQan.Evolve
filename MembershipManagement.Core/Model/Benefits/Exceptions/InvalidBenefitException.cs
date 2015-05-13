using System;

namespace MembershipManagement.Core.Exceptions
{
    public class InvalidBenefitException : ApplicationException
    {
        public InvalidBenefitException(string message) : base(message)
        {
        }
    }
}