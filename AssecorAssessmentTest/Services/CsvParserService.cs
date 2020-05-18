using AssecorAssessmentTest.Mappers;
using AssecorAssessmentTest.Model;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssecorAssessmentTest.Services
{
    public class CsvParserService : IParserService
    {
        private const string path = @"C:\sample-input.csv";
     
        public List<PersonModel> ReadFileToEmployeeModel()
        {
            try
            {
                using (var reader = new StreamReader(path, Encoding.Default))
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {                  
                    csv.Configuration.IgnoreBlankLines = true;
                    csv.Configuration.Delimiter = ", ";  
                    csv.Configuration.HasHeaderRecord = false;                    
                    csv.Configuration.MissingFieldFound = null;

                    List<PersonModel> records = new List<PersonModel>();

                    List<string> elements = new List<string>();
                    while (csv.Read())
                    {
                        #region GetField
                        var temp0 = csv.GetField(0);
                        var temp1 = csv.GetField(1);
                        var temp2 = csv.GetField(2);
                        var ID = csv.GetField(3);
                        #endregion

                        PersonModel personModel = null;

                        if (string.IsNullOrEmpty(ID))
                        {
                            if (!string.IsNullOrEmpty(temp0)) elements.Add(temp0);
                            if (!string.IsNullOrEmpty(temp1)) elements.Add(temp1);
                            if (!string.IsNullOrEmpty(temp2)) elements.Add(temp2);                           

                            if (elements.Count == 4)
                            {                                
                                if(int.TryParse(elements[3], out int IdElement))
                                {
                                    personModel = new PersonModel()
                                    {
                                        FirstName = elements[0],
                                        Lastname = elements[1],
                                        City = elements[2],
                                        Id = IdElement
                                    };

                                    ExtractZipFromCity(ref personModel);
                                    records.Add(personModel);
                                }
                                
                                elements.Clear();
                            }
                            
                            continue;
                            
                        }
                        else
                        {
                            elements.Clear();
                            personModel = csv.GetRecord<PersonModel>();
                            ExtractZipFromCity(ref personModel);
                        }
                        
                        records.Add(personModel);
                    }                   

                    return records;
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
            catch (FieldValidationException e)
            {
                throw new Exception(e.Message);
            }
            catch (CsvHelperException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void ExtractZipFromCity(ref PersonModel personCopy)
        {
            string zipCity = personCopy.City;
            string[] zipCityArray = zipCity.Split(' ');

            if (zipCityArray.Length == 2)
            {
                personCopy.Zipcode = zipCityArray[0];
                personCopy.City = zipCityArray[1]; 
            }
        }        

        public void WriteNewFile(List<PersonModel> personModels)
        {
            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw, System.Globalization.CultureInfo.InvariantCulture))
            {
                cw.Configuration.Delimiter = ", ";

                foreach (PersonModel person in personModels)
                {                    
                    cw.WriteRecord<PersonModel>(person);
                    cw.NextRecord();
                }
            }
        }
    }
}
