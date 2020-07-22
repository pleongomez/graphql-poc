using graphql.poc.core.Models;
using graphql.poc.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql.poc.server.data
{
    public class DataSeeder
    {

        public static void SeedConferences(NbaContext context)
        {
            context.Teams.AddRange(
                new Team
                {
                    Id = 1,
                    Name = "Boston Celtics",
                    City = "Boston",
                    Coach = "Brad Stevens",
                    HomeField = "TD garden"
                },
                new Team
                {
                    Id = 2,
                    Name = "Angeles Lakers",
                    City = "Los Angeles",
                    Coach = "Frank Vogel",
                    HomeField = "Staples Center"
                },
                new Team
                {
                    Id = 3,
                    Name = "Angeles Clippers",
                    City = "Los Angeles",
                    Coach = "Doc Rivers",
                    HomeField = "Staples Center"
                }
            );


            context.Players.AddRange(
                new Player
                {
                    Id = 1,
                    Name = "Jayson Tatum",
                    Number = 0,
                    Nationality = "USA",
                    Position = "Fordward",
                    CurrentTeam = context.Teams.FirstOrDefault(t => t.Id == 1)
                },
                new Player
                {
                    Id = 2,
                    Name = "Lebron James",
                    Number = 23,
                    Nationality = "USA",
                    Position = "Fordward",
                    CurrentTeam = context.Teams.FirstOrDefault(t => t.Id == 2)
                },
                new Player
                {
                    Id = 3,
                    Name = "Kawhi Leonard",
                    Number = 2,
                    Nationality = "USA",
                    Position = "Fordward",
                    CurrentTeam = context.Teams.FirstOrDefault(t => t.Id == 3)
                }
            );

            context.SaveChanges();
        }
    }
}
