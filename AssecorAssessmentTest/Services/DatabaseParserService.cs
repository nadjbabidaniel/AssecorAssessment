using AssecorAssessmentTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AssecorAssessmentTest.Services
{
    public class DatabaseParserService : IParserService
    {
        private readonly PersonDbContext _context;

        public DatabaseParserService(PersonDbContext context)
        {
            _context = context;
        }
        public List<PersonModel> ReadCsvFileToEmployeeModel()
        {
            return _context.Persons.ToList();
        }

        public void WriteNewCsvFile(List<PersonModel> personModels)
        {           
            foreach (var person in personModels)
            {
                var tempPerson = _context.Persons.FirstOrDefault(x => x.Id == person.Id);
                if(tempPerson != null)
                {
                    tempPerson.FirstName = person.FirstName;
                    tempPerson.Lastname = person.Lastname;
                    tempPerson.Zipcode = person.Zipcode;
                    tempPerson.City = person.City;
                    tempPerson.Color = person.Color;

                    _context.Update(tempPerson);
                }
                else
                {
                    _context.Persons.Add(person);
                }                   
            }
            
            _context.SaveChanges();
        }
    }
}
