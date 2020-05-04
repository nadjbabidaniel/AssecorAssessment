using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssecorAssessmentTest.Model
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonModel>().HasData(
                new PersonModel() { Id = 1, Lastname = "Petersen", FirstName = "Peter", City = "Stralsund", Zipcode = "18439", /*Color = "blau"*/ },
                new PersonModel() { Id = 6, Lastname = "Fujitsu,", FirstName = "Tastatur,", City = "Japan,", Zipcode = "42342", /*Color = "türkis"*/ }
                );
        }
    }
}
