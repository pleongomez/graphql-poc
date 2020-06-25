using System;
using System.Collections.Generic;
using System.Text;

namespace graphql.poc.core.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
        public Team CurrentTeam { get; set; }
    }
}
