using GraphQL;
using GraphQL.Types;
using System;

namespace graphql.poc.schema
{
    public class NbaSchema: Schema
    {
        public NbaSchema(IDependencyResolver dependencyResolver): base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<QueryType>();
        }
    }
}
