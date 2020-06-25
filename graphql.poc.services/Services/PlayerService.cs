using graphql.poc.core.Models;
using graphql.poc.core.Repository;
using graphql.poc.core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace graphql.poc.services.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<Player>> Get()
        {
            return await _playerRepository.Get().ConfigureAwait(false);
        }
    }
}
