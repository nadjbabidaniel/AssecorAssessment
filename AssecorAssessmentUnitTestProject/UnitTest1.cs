using AssecorAssessmentTest.Controllers;
using AssecorAssessmentTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssecorAssessmentUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {


            // Arrange
            var controller = new WeatherForecastController(new CsvParserService());


            // Act
            var response = controller.GetPersons();

        }
    }
}