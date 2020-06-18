using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rickandmorty.graphql.client.Models.Responses
{
    public class EpisodeResponseType
    {
        public EpisodeType episodes { get; set; }
    }

    public class EpisodeSingleResponseType
    {
        public EpisodeResultType episode { get; set; }
    }

    public class EpisodeType
    {
        public InfoType info { get; set; }
        public List<EpisodeResultType> results { get; set; }
    }

    public class EpisodeResultType
    {
        public string id { get; set; }
        public string name { get; set; }
        public string air_date { get; set; }
        public string episode { get; set; }
        public CharacterResultType[] characters { get; set; }
        public string created { get; set; }
    }
}
