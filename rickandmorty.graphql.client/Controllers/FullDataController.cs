using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Mvc;
using rickandmorty.graphql.client.Models.Responses;

namespace rickandmorty.graphql.client.Controllers
{
    public class FullDataController : Controller
    {
        private readonly GraphQLHttpClient client;

        public FullDataController(GraphQLHttpClient client)
        {
            this.client = client;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query {
                    characters {
                        results {
                            id
                            name
                        }
                    }
                    episodes{
                        results {
                            id
                            name
                        }
                    }
                    locations {
                        results {
                            id
                            name
                        }
                    }
                }"
            };

            var response = await client.SendQueryAsync<FullResponseType>(query);
            return View(response.Data);
        }
    }
}
