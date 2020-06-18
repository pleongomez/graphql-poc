using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rickandmorty.graphql.client.Models.Responses
{
    public class InfoType
    {
        public int count { get; set; }
        public int pages { get; set; }
        public int? next { get; set; }
        public int? prev { get; set; }
    }
}
