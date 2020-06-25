using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace graphql.poc.core.Repository
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int Id);
        Task<List<T>> Get(Expression<Func<T, bool>> predicate);
    }
}
