using graphql.poc.core.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace graphql.poc.schema.Types
{
    public class TeamType: ObjectGraphType<Team>
    {
        public TeamType()
        {
            Field<IntGraphType>("Id", resolve: context => context.Source.Id);
            Field(f => f.Name);
            Field(f => f.City);
            Field(f => f.HomeField);
            Field(f => f.Coach);
            Field(
                name: "Roster",
                type: typeof(ListGraphType<PlayerType>),
                resolve: context => context.Source.Roster
            );
        }
    }
}
