using GeneradorComitesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorComitesAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonsComitee>().HasKey(pc => new { pc.PersonId, pc.ComiteeId });
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Comitee> Comitees { get; set; }
        public DbSet<PersonsComitee> PersonsComitees { get; set; }
    }
}
