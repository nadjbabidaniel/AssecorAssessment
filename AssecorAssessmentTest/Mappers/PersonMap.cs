using AssecorAssessmentTest.Model;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssecorAssessmentTest.Mappers
{    
    public sealed class PersonMap : ClassMap<PersonModel>
    {
        public PersonMap()
        {            
            //Map(m => m.Name).Name(Constants.CsvHeaders.Name);
            //Map(m => m.Lastname).Name(Constants.CsvHeaders.Lastname);
            ////Map(m => m.Zipcode).Name(Constants.CsvHeaders.Zipcode);
            //Map(m => m.City).Name(Constants.CsvHeaders.City);
            //Map(m => m.Id).Name(Constants.CsvHeaders.Id);
            ////Map(m => m.Color).Name(Constants.CsvHeaders.Color);  

            Map(m => m.FirstName).Index(0);
            Map(m => m.Lastname).Index(1);
            Map(m => m.City).Index(2);
            Map(m => m.Id).Index(3);
        }
    }
}
