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

        [TestMethod]
        [TestCategory("Integration")]
        public void WriteNewCsvFileTest()
        {
            // Arrange        
            IParserService service = new CsvParserService();

            // Act
            var personsModel = service.ReadCsvFileToEmployeeModel();
            if (personsModel == null || personsModel.Count == 0) return;
            personsModel.RemoveAt(0);

            service.WriteNewCsvFile(personsModel);
            
        }
    }
}
