using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Mvc;

namespace rickandmorty.graphql.client.Controllers
{
    public class LocationController : Controller
    {
        private readonly GraphQLHttpClient client;

        public LocationController()
        {
            this.client = client;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}