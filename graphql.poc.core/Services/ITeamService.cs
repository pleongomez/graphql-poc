using graphql.poc.core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace graphql.poc.core.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> Get();
    }
}
