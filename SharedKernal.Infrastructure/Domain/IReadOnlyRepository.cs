using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Infrastructure.Domain
{
    public interface IReadOnlyRepository<T, TId> where T : AggregateRoot
    {
        T FindBy(TId id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindById(TId id);
    }

}
