using AssecorAssessmentTest.Mappers;
using CsvHelper.Configuration.Attributes;

namespace AssecorAssessmentTest.Model
{
    public class PersonModel
    {        
        public string Lastname { get; set; }                

        public string FirstName { get; set; }
      
        public string Zipcode { get; set; }        

        public string City { get; set; }
                
        public int Id { get; set; }

        public string Color { get; set; }
    }
}
