using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernal.Infrastructure.Domain;

namespace MembershipManagement.Core.Model.MembershipCategory
{
    public interface IMembershipCategoryRepository : IRepository<Core.MembershipCategory,Guid>
    {
    }
}
