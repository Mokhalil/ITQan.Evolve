using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Infrastructure.Domain.Specification
{
    public interface IValidator<T>
    {
        bool IsValid();
        IEnumerable<BusinessRule> GetBrokenBusinessRules();
    }
}
