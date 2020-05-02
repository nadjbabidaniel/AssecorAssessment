using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssecorAssessmentTest.Model
{
    public class CopyCsvModel
    {
        //Lastname
        [Index(0)] 
        public string? FirstElement { get; set; }

        //Firstname
        [Index(1)]  
        public string? SecondElement { get; set; }

        //Lastname Zip Code and City
        [Index(2)]  
        public string? ThirdElement { get; set; }

        //Id
        [Index(3)] 
        public int? FourthElement { get; set; }

    }
}
