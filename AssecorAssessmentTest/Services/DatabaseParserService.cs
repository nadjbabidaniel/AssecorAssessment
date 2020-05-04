using AssecorAssessmentTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssecorAssessmentTest.Services
{
    public class DatabaseParserService : IParserService
    {
        private readonly PersonDbContext _context;

        public DatabaseParserService(PersonDbContext context)
        {
            _context = context;
        }
        public List<PersonModel> ReadCsvFileToEmployeeModel()
        {
            throw new NotImplementedException();
        }

        public void WriteNewCsvFile(List<PersonModel> personModels)
        {
            throw new NotImplementedException();
        }
    }
}
