using graphql.poc.core.Models;
using graphql.poc.core.Repository;
using graphql.poc.core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace graphql.poc.services.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository; 
        }
        public async Task<IEnumerable<Team>> Get()
        {
            return await _teamRepository.Get().ConfigureAwait(false);
        }
    }
}
