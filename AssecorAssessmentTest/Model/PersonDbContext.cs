using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssecorAssessmentTest.Model
{
    public class PersonDbContext : DbContext 
    {
        public DbSet<PersonModel> Persons { get; set; }

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)  { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }        
    }
}
