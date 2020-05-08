using AssecorAssessmentTest.Controllers;
using AssecorAssessmentTest.Model;
using AssecorAssessmentTest.Services;
using Moq;
using Newtonsoft.Json;
 
using System.Collections.Generic;
 
using Xunit;

namespace AssecorAssessmentUnitTestProject
{
    public class PersonApiTest_XUnit
    {
        private static readonly PersonModel PersonA = new PersonModel() { Id = 1, Lastname = "Petersen", FirstName = "Peter", City = "Stralsund", Zipcode = "18439", Color = "blau" };
        private static readonly PersonModel PersonB = new PersonModel() { Id = 6, Lastname = "Fujitsu,", FirstName = "Tastatur,", City = "Japan,", Zipcode = "42342", Color = "türkis" };
        private static readonly List<PersonModel> Persons = new List<PersonModel>() { PersonA, PersonB };

        private Mock<IParserService> ParserService = new Mock<IParserService>();
        private readonly PersonsController controllerCtor;


        public PersonApiTest_XUnit()
        {
            ParserService.Setup(p => p.ReadFileToEmployeeModel()).Returns(Persons);
            controllerCtor = new PersonsController(ParserService.Object);
        }

        private static readonly Dictionary<int, string> Dictionary = new Dictionary<int, string>()
        {
            { 1, "blau"}, { 2, "grün"}, { 3, "violett"},{ 4, "rot"}, { 5, "gelb"}, { 6, "türkis"}, { 7, "weiß"}
        };

        [Fact]
        public void GetPersons_ShouldReturnPersons()
        {       
            // Act
            var jsonResponse = controllerCtor.GetPersons();
            List<PersonModel> response = JsonConvert.DeserializeObject<List<PersonModel>>(jsonResponse);

            // Assert
            Assert.Equal(2, response.Count);
        }

        [Fact]
        public void GetPersonsId_ShouldReturnOnePerson()
        {            
            // Act
            var jsonResponse = controllerCtor.GetPerson(PersonA.Id);
            List<PersonModel> response = JsonConvert.DeserializeObject<List<PersonModel>>(jsonResponse);

            // Assert
            Assert.Single(response);
            Assert.Equal(PersonA.Zipcode, response[0].Zipcode);
            Assert.Equal(Dictionary[PersonA.Id], response[0].Color);
        }

        [Fact]
        public void GetPersonsId_ShouldReturnNull()
        {
            // Act
            var jsonResponse = controllerCtor.GetPerson(5);
            List<PersonModel> response = JsonConvert.DeserializeObject<List<PersonModel>>(jsonResponse);

            // Assert
            Assert.Empty(response);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        public void GetPersonsInlineId_ShouldReturnOnePerson(int id)
        {           
            // Act
            var jsonResponse = controllerCtor.GetPerson(id);
            List<PersonModel> response = JsonConvert.DeserializeObject<List<PersonModel>>(jsonResponse);

            // Assert
            Assert.Single(response);
            Assert.Equal(Dictionary[response[0].Id], response[0].Color);
        }

        [Fact]
        public void GetColor_ShouldReturnPersonsList_WithSameColor()
        {
            // Act
            var jsonResponse = controllerCtor.GetColor(PersonB.Color);
            List<PersonModel> response = JsonConvert.DeserializeObject<List<PersonModel>>(jsonResponse);

            // Assert
            Assert.Single(response);
            Assert.Equal(Dictionary[PersonB.Id], response[0].Color);
        }

        [Fact]
        public void InsertPerson_ShouldInsertPerson()
        {
            // Act
            controllerCtor.InsertPerson(Persons);   // Service is Mock so it wont be overridden        
        }
    }
}
