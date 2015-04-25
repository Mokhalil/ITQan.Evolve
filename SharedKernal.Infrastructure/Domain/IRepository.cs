using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Infrastructure.Domain
{
    public interface IRepository<T, TId> : IReadOnlyRepository<T, TId>
                                     where T : AggregateRoot
    {
        void Save(T entity);
        void Add(T entity);
        void Remove(T entity);
    }
}
