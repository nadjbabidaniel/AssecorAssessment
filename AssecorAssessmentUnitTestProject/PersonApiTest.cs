using AssecorAssessmentTest.Controllers;
using AssecorAssessmentTest.Model;
using AssecorAssessmentTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AssecorAssessmentUnitTestProject
{
    [TestClass]
    public class PersonApiTest
    {
        private static readonly PersonModel PersonA = new PersonModel { Id = 1, Lastname = "Petersen", FirstName = "Peter", City = "Stralsund", Zipcode = "18439", Color = "blau"};
        private static readonly PersonModel PersonB = new PersonModel { Id = 6, Lastname = "Fujitsu,", FirstName = "Tastatur,", City = "Japan,", Zipcode = "42342", Color = "t�rkis" };
        private static readonly List<PersonModel> Persons = new List<PersonModel> { PersonA, PersonB };

        private readonly Mock<IParserService> _parserService = new Mock<IParserService>();

        public PersonApiTest()
        {
            _parserService.Setup(p => p.ReadFileToEmployeeModel()).Returns(Persons);
        }

        private static readonly Dictionary<int, string> Dictionary = new Dictionary<int, string>()
        {
            { 1, "blau"}, { 2, "gr�n"}, { 3, "violett"},{ 4, "rot"}, { 5, "gelb"}, { 6, "t�rkis"}, { 7, "wei�"}
        };

        [TestMethod]
        public void GetPersons_ShouldReturnPersons()
        {            
             // Arrange                               
            var controller = new PersonsController(_parserService.Object);

            // Act
            var jsonResponse = controller.GetPersons();
            List<PersonModel> response = JsonConvert.DeserializeObject<List<PersonModel>>(jsonResponse);

            // Assert
            Assert.AreEqual(response.Count, 2);
        }

        [TestMethod]
        public void GetPersonsInlineId_ShouldReturnOnePerson()
        {
            // Arrange          
            var controller = new PersonsController(_parserService.Object);

            // Act
            var jsonResponse = controller.GetPerson(PersonA.Id);
            List<PersonModel> response = JsonConvert.DeserializeObject<List<PersonModel>>(jsonResponse);

            // Assert
            Assert.AreEqual(response.Count, 1);
            Assert.AreEqual(response[0].Zipcode, PersonA.Zipcode);
            Assert.AreEqual(response[0].Color, Dictionary[PersonA.Id]);
        }

        [TestMethod]
        public void GetColor_ShouldReturnPersonsList_WithSameColor()
        {
            // Arrange           
            var controller = new PersonsController(_parserService.Object);

            // Act
            var jsonResponse = controller.GetColor(PersonB.Color);
            List<PersonModel> response = JsonConvert.DeserializeObject<List<PersonModel>>(jsonResponse);

            // Assert
            Assert.AreEqual(response.Count, 1);
            Assert.AreEqual(response[0].Color, Dictionary[PersonB.Id]);
        }

        [TestMethod]
        public void InsertPerson_ShouldInsertPerson()
        {
            // Arrange          
            var controller = new PersonsController(_parserService.Object);

            // Act
            controller.InsertPerson(Persons);   // Service is Mock so it wont be overridden        
        }
    }
}
