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
        [TestMethod]
        public void GetPersonsTest()
        {            
            PersonModel person = new PersonModel()
            {
                Id = 1,
                Lastname = "Petersen",
                FirstName = "Peter",
                City = "Stralsund",
                Zipcode = "18439",                
                Color = "blau"
            };

            List<PersonModel> persons = new List<PersonModel>() { person };

            // Arrange
            var parserService = new Mock<IParserService>();
            parserService.Setup(p => p.ReadCsvFileToEmployeeModel()).Returns(persons);            
            
            var controller = new PersonsController(parserService.Object);

            // Act
            var jsonResponse = controller.GetPersons();
            List<PersonModel>  response = JsonConvert.DeserializeObject<List<PersonModel>>(jsonResponse);

            // Assert
            Assert.AreEqual(response.Count, 1);
        }
    }
}
