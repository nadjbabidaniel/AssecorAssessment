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
    public class CsvParserService : ICsvParserService
    {
        private const string path = @"C:\Users\dnadjbabi\Downloads\assecor-assessment-backend-master\sample-input.csv";
     
        public List<PersonModel> ReadCsvFileToEmployeeModel()
        {
            try
            {
                using (var reader = new StreamReader(path, Encoding.Default))
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {
                    //csv.Configuration.RegisterClassMap<PersonMap>();
                    //csv.Configuration.HeaderValidated = null;

                    csv.Configuration.IgnoreBlankLines = true;
                    csv.Configuration.Delimiter = ", ";  // remove empty space and do it with Trim()
                    csv.Configuration.HasHeaderRecord = false;                    
                    csv.Configuration.MissingFieldFound = null;

                    List<CopyCsvModel> recordsCopy = new List<CopyCsvModel>();

                    List<string> elements = new List<string>();
                    while (csv.Read())
                    {
                        #region GetField
                        var temp0 = csv.GetField(0);
                        var temp1 = csv.GetField(1);
                        var temp2 = csv.GetField(2);
                        var ID = csv.GetField(3);
                        #endregion

                        CopyCsvModel recordCopy = null;

                        if (string.IsNullOrEmpty(ID))
                        {
                            if (!string.IsNullOrEmpty(temp0)) elements.Add(temp0);
                            if (!string.IsNullOrEmpty(temp1)) elements.Add(temp1);
                            if (!string.IsNullOrEmpty(temp2)) elements.Add(temp2);                           

                            if (elements.Count == 4)
                            {                                
                                if(int.TryParse(elements[3], out int IdElement))
                                {
                                    recordCopy = new CopyCsvModel()
                                    {
                                        FirstElement = elements[0],
                                        SecondElement = elements[1],
                                        ThirdElement = elements[2],
                                        FourthElement = IdElement
                                    };

                                    recordsCopy.Add(recordCopy);
                                }
                                
                                elements.Clear();
                            }
                            
                            continue;
                            
                        }
                        else
                        {
                            elements.Clear();
                            recordCopy = csv.GetRecord<CopyCsvModel>();
                        }
                        
                        recordsCopy.Add(recordCopy);
                    }

                    var records = ValidateData(recordsCopy);

                    //var records = csv.GetRecords<PersonModel>().ToList();
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

        private List<PersonModel> ValidateData(List<CopyCsvModel> recordsCopy)
        {
            

            return null;
        }

        public void WriteNewCsvFile(string path, List<PersonModel> employeeModels)
        {
            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw, System.Globalization.CultureInfo.InvariantCulture))
            {
                cw.WriteHeader<PersonModel>();
                cw.NextRecord();
                foreach (PersonModel emp in employeeModels)
                {
                    cw.WriteRecord<PersonModel>(emp);
                    cw.NextRecord();
                }
            }
        }
    }
}
