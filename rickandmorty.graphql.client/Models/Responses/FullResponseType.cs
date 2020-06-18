using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rickandmorty.graphql.client.Models.Responses
{
    public class FullResponseType
    {
        public CharacterType characters { get; set; }
        public EpisodeType episodes { get; set; }
        public LocationType locations { get; set; }
    }
}
