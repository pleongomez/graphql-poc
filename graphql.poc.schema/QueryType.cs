using graphql.poc.core.Models;
using graphql.poc.core.Repository;
using graphql.poc.core.Services;
using graphql.poc.schema.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace graphql.poc.schema
{
    public class QueryType : ObjectGraphType
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;


        public QueryType(ITeamService teamService, IPlayerService playerService)
        {
            _teamService = teamService;
            _playerService = playerService;

            Name = "Query";
            
            Field<ListGraphType<PlayerType>>(
                name: "players",
                resolve: context => _playerService.Get()
            );

            Field<ListGraphType<TeamType>>(
                name: "teams",
                resolve: context => _teamService.Get()
            );
        }
    }
}
