using System;
using System.Collections.Generic;
using System.Text;

namespace graphql.poc.core.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string HomeField { get; set; }
        public string Coach { get; set; }
        public IEnumerable<Player> Roster { get; set; }
    }
}
