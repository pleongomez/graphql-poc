using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rickandmorty.graphql.client.Models.Responses
{
    public class CharacterResponseType
    {
        public CharacterType characters { get; set; }
    }

    public class CharacterSingleResponseType
    {
        public CharacterResultType character { get; set; }
    }

    public class CharacterType
    {
        public InfoType info { get; set; }
        public List<CharacterResultType> results { get; set; }
    }

    public class CharacterResultType
    {
        public string id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public LocationResultType location { get; set; }
        public string image { get; set; }
        public EpisodeResultType[] episode { get; set; }
        public string created { get; set; }

    }
}
