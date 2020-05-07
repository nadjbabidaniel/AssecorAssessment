using AssecorAssessmentTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssecorAssessmentUnitTestProject
{
    [TestClass]
    public class CsvParserTest
    {
        [TestMethod]
        [TestCategory("Integration")]
        public void ReadCsvFile_ShouldReturnAllPersons()
        {
            // Arrange        
            IParserService service = new CsvParserService();

            // Act
            var personsModel = service.ReadFileToEmployeeModel();

            // Assert
            Assert.AreEqual(personsModel.Count, 10);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void WriteNewCsvFile_ShouldWriteAllPersons()
        {
            // Arrange        
            IParserService service = new CsvParserService();

            // Act
            var personsModel = service.ReadFileToEmployeeModel();
            
            if (personsModel == null || personsModel.Count == 0) return;
            //personsModel.RemoveAt(0);

            service.WriteNewFile(personsModel);
            
        }
    }
}
