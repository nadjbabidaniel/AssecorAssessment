using AssecorAssessmentTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssecorAssessmentTest.Services
{
    public interface ICsvParserService
    {
        List<PersonModel> ReadCsvFileToEmployeeModel();
        void WriteNewCsvFile(string path, List<PersonModel> personModels);
    }
}
