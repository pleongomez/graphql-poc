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
    public class EpisodeController : Controller
    {
        private readonly GraphQLHttpClient client;

        public EpisodeController(GraphQLHttpClient client)
        {
            this.client = client;
        }

        public async Task<IActionResult> Index([FromRoute] int id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query results ($pg: Int){
                  episodes (page: $pg)  {
                    info {
                        count
                        pages
                        next
                        prev
                    }
                    results {
                        id
                        name
                        air_date
                        episode
                    }
                  }
                }",
                Variables = new { pg = id }
            };

            ViewData["Page"] = id == 0 ? 1 : id;
            var response = await client.SendQueryAsync<EpisodeResponseType>(query);
            return View(response.Data);
        }

        public async Task<IActionResult> Detail([FromRoute] string id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query filter($episode: ID) {
                  episode (id: $episode ) {
                    name
                    air_date
                    episode
                    characters
                        {
                            name
                        }
                    created
                  }
                }",
                Variables = new { episode = id }
            };

            var response = await client.SendQueryAsync<EpisodeSingleResponseType>(query);
            return View(response.Data);
        }
    }
}