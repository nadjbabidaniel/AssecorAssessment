using AssecorAssessmentTest.Mappers;
using CsvHelper.Configuration.Attributes;

namespace AssecorAssessmentTest.Model
{
    public class PersonModel
    {

        [Index(3)]
        public int Id { get; set; }

        [Index(0)]
        public string Lastname { get; set; }

        [Index(1)]
        public string FirstName { get; set; }
      
        public string Zipcode { get; set; }

        [Index(2)]
        public string City { get; set; }      

        public string Color { get; set; }
    }
}
