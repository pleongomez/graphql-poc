using graphql.poc.core.Models;
using graphql.poc.core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace graphql.poc.repository.Repository
{
    public class TeamRepository: ITeamRepository
    {
        private readonly NbaContext _context;

        public TeamRepository(NbaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> Get()
        {
            try
            {
                var teams = await _context.Teams
                    .Include(o => o.Roster)
                    .ToListAsync() ;
                return teams;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.GetBaseException().Message);
            }
        }

        public async Task<Team> Get(int Id)
        {
            try
            {
                var team = await _context.Teams
                    .Include(o => o.Roster)
                    .FirstOrDefaultAsync(t => t.Id == Id);
                    
                return team;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.GetBaseException().Message);
            }
        }

        public async Task<List<Team>> Get(Expression<Func<Team, bool>> predicate)
        {
            try
            {
                var teams =  await _context.Teams
                    .Include(o => o.Roster)
                    .Where(predicate)
                    .ToListAsync().ConfigureAwait(false);

                return teams;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.GetBaseException().Message);
            }
        }
    }
}
