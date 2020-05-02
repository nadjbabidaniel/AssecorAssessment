using AssecorAssessmentTest.Controllers;
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
            var controller = new WeatherForecastController(null);


            // Act
            var response = controller.Get();

        }
    }
}
