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
        private static readonly PersonModel Person = new PersonModel() { Id = 1, Lastname = "Petersen", FirstName = "Peter", City = "Stralsund", Zipcode = "18439", Color = "blau"};
        private static readonly List<PersonModel> Persons = new List<PersonModel>() { Person };

        private Mock<IParserService> ParserService = new Mock<IParserService>();

        public PersonApiTest()
        {
            ParserService.Setup(p => p.ReadCsvFileToEmployeeModel()).Returns(Persons);
        }

        private static readonly Dictionary<int, string> Dictionary = new Dictionary<int, string>()
        {
            { 1, "blau"}, { 2, "grün"}, { 3, "violett"},{ 4, "rot"}, { 5, "gelb"}, { 6, "türkis"}, { 7, "weiß"}
        };

        [TestMethod]
        public void GetPersonsTest()
        {            
             // Arrange                               
            var controller = new PersonsController(ParserService.Object);

            // Act
            var jsonResponse = controller.GetPersons();
            List<PersonModel> response = JsonConvert.DeserializeObject<List<PersonModel>>(jsonResponse);

            // Assert
            Assert.AreEqual(response.Count, 1);
        }

        [TestMethod]
        public void GetPersonsIdTest()
        {
            // Arrange          
            var controller = new PersonsController(ParserService.Object);

            // Act
            var jsonResponse = controller.GetPerson(Person.Id);
            List<PersonModel> response = JsonConvert.DeserializeObject<List<PersonModel>>(jsonResponse);

            // Assert
            Assert.AreEqual(response.Count, 1);
            Assert.AreEqual(response[0].Color, Dictionary[Person.Id]);
        }

        [TestMethod]
        public void GetColorTest()
        {
            // Arrange           
            var controller = new PersonsController(ParserService.Object);

            // Act
            var jsonResponse = controller.GetColor(Person.Color);
            List<PersonModel> response = JsonConvert.DeserializeObject<List<PersonModel>>(jsonResponse);

            // Assert
            Assert.AreEqual(response.Count, 1);
            Assert.AreEqual(response[0].Color, Dictionary[Person.Id]);
        }
    }
}
