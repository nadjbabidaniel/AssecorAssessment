using AssecorAssessmentTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssecorAssessmentUnitTestProject
{
    [TestClass]
    public class CsvParserTest
    {
        [TestMethod]
        [TestCategory("Integration")]
        public void ReadCsvFileTest()
        {
            // Arrange        
            IParserService service = new CsvParserService();

            // Act
            var personsModel = service.ReadCsvFileToEmployeeModel();

            // Assert
            Assert.AreEqual(personsModel.Count, 10);
        }
    }
}
