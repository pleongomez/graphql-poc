using Microsoft.EntityFrameworkCore.Migrations;

namespace graphql.poc.repository.Migrations
{
    public partial class LoadData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name", "City", "HomeField", "Coach" },
                values: new object[,]
                {
                    {1, "Boston Celtics", "Boston", "TD Garden", "Brad Stevens" },
                    {2, "Angeles Lakers", "Los Angeles", "Staples Center", "Frank Vogel" },
                    {3, "Angeles Clippers", "Los Angeles", "Staples Center", "Doc Rivers" }
                }
            );

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name", "Number", "Position", "Nationality", "CurrentTeamId" },
                values: new object[,]
                {
                    {1, "Jayson Tatum", 0, "Fordward", "USA", 1 },
                    {2, "Lebron James", 23, "Fordward", "USA", 2 },
                    {3, "Kawhi Leonard", 2, "Fordward", "USA", 3 },
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
