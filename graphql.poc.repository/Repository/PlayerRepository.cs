using graphql.poc.core.Models;
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
    public class PlayerRepository:  IPlayerRepository
    {
        private readonly NbaContext _context;

        public PlayerRepository(NbaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> Get()
        {
            try
            {
                var players = await _context.Players
                    .Include(p => p.CurrentTeam)
                    .ToListAsync();
                return players;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.GetBaseException().Message);
            }
        }

        public async Task<Player> Get(int Id)
        {
            try
            {
                var player = await _context.Players
                    .Include(p => p.CurrentTeam)
                    .FirstOrDefaultAsync(t => t.Id == Id);

                return player;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.GetBaseException().Message);
            }
        }

        public async Task<List<Player>> Get(Expression<Func<Player, bool>> predicate)
        {
            try
            {
                var players = await _context.Players
                    .Include(p => p.CurrentTeam)
                    .Where(predicate)
                    .ToListAsync().ConfigureAwait(false);

                return players;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.GetBaseException().Message);
            }
        }
    }
}
