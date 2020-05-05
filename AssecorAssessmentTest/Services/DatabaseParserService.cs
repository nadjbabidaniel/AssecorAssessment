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
        public List<PersonModel> ReadFileToEmployeeModel()
        {
            try
            {
                var personList = _context.Persons.ToList();
                ExtractZipFromCity(ref personList);

                return personList == null ? new List<PersonModel>() : personList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void ExtractZipFromCity(ref List<PersonModel> personList)
        {
            foreach (var personCopy in personList)
            {
                string zipCity = personCopy.City;
                string[] zipCityArray = zipCity.Split(' ');

                if (zipCityArray.Length == 2)
                {
                    personCopy.Zipcode = zipCityArray[0];
                    personCopy.City = zipCityArray[1];
                }
            }            
        }

        public void WriteNewFile(List<PersonModel> personModels)
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

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
