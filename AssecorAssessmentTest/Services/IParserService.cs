using AssecorAssessmentTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssecorAssessmentTest.Services
{
    public interface IParserService
    {
        List<PersonModel> ReadFileToEmployeeModel();
        void WriteNewFile(List<PersonModel> personModels);
    }
}
