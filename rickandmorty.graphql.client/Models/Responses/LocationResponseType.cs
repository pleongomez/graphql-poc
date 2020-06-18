using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rickandmorty.graphql.client.Models.Responses
{
    public class LocationResponseType
    {
        public LocationType locations { get; set; }
    }

    public class LocationType
    {
        public InfoType info { get; set; }
        public List<LocationResultType> results { get; set; }
    }

    public class LocationResultType
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string dimensions { get; set; }
        public CharacterResultType[] residents { get; set; }
        public string created { get; set; }

    }
}
