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
    public class CharacterController : Controller
    {
        private readonly GraphQLHttpClient client;

        public CharacterController(GraphQLHttpClient client)
        {
            this.client = client;
        }


        public async Task<IActionResult> Index([FromRoute] int id = 1)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query results($pg: Int) {
                  characters (page: $pg)  {
                    info {
                        count
                        pages
                        next
                        prev
                    }
                    results {
                        name
                        created
                        id
                        image
                        species
                    }
                  }
                }",
                Variables = new { pg = id }
            };

            var response = await client.SendQueryAsync<CharacterResponseType>(query);
            return View(response.Data);
        }

        public async Task<IActionResult> Detail([FromRoute] string id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query filter($character: ID) {
                    character (id: $character) {
                        name
                        status
                        species
                        episode {
                            id
                            name
                        }
                        location {
                            name
                        }
                    }
                }",
                Variables = new { character = id }
            };

            var response = await client.SendQueryAsync<CharacterSingleResponseType>(query);
            return View(response.Data.character);
        }
    }
}