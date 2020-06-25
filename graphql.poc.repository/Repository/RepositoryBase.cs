using graphql.poc.core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace graphql.poc.repository.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected DbContext Context { get; }

        protected RepositoryBase(DbContext context)
        {
            this.Context = context;
        }

        public async Task<IEnumerable<T>> Get()
        {
            try
            {
                return await Context.Set<T>().ToListAsync().ConfigureAwait(false);
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.GetBaseException().Message);
            }
        }

        public async Task<T> Get(int Id)
        {
            try
            {
                var result = await Context.Set<T>().FindAsync(Id).ConfigureAwait(false);
                return result;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.GetBaseException().Message);
            }
        }

        public async Task<List<T>> Get(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await Context.Set<T>().Where(predicate).ToListAsync().ConfigureAwait(false);
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.GetBaseException().Message);
            }
        }
    }
}
