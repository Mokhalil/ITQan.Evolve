using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Infrastructure.Domain.Exceptions
{
    public class ValueObjectIsInvalidException : ApplicationException
    {
        public ValueObjectIsInvalidException(string message) : base(message)
        {
        }
    }
}
