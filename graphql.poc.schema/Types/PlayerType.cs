using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using graphql.poc.core.Models;

namespace graphql.poc.schema.Types
{
    
    public class PlayerType: ObjectGraphType<Player>
    {
        public PlayerType()
        {
            Field<IntGraphType>("Id", resolve: context => context.Source.Id);
            Field(f => f.Name);
            Field(f => f.Nationality);
            Field(f => f.Position);
            Field<IntGraphType>("Number", resolve: context => context.Source.Number);
            Field(
                name: "Team",
                type: typeof(TeamType),
                resolve: context => context.Source.CurrentTeam
            );
        }
    }
}
