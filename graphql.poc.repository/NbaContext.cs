using graphql.poc.core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace graphql.poc.repository
{
    public class NbaContext : DbContext
    {
        public NbaContext() : base() { }

        public NbaContext(DbContextOptions<NbaContext> options) : base(options){ }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Team>().HasKey(k => new { k.Id });
            builder.Entity<Player>().HasKey(k => new { k.Id });
            builder.Entity<Player>().HasOne(k => k.CurrentTeam).WithMany(j => j.Roster);
        }
    }
}
