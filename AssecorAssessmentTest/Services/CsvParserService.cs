using AssecorAssessmentTest.Model;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AssecorAssessmentTest.Services
{
    public class CsvParserService : IParserService
    {
        private const string Path = @"C:\sample-input.csv";
     
        public List<PersonModel> ReadFileToEmployeeModel()
        {
            try
            {
                using var reader = new StreamReader(Path, Encoding.Default);
                using var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
                csv.Configuration.IgnoreBlankLines = true;
                csv.Configuration.Delimiter = ", ";
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.MissingFieldFound = null;

                var records = new List<PersonModel>();

                var elements = new List<string>();
                while (csv.Read())
                {
                    #region GetField

                    var temp0 = csv.GetField(0);
                    var temp1 = csv.GetField(1);
                    var temp2 = csv.GetField(2);
                    var id = csv.GetField(3);

                    #endregion

                    PersonModel personModel = null;

                    if (string.IsNullOrEmpty(id))
                    {
                        if (!string.IsNullOrEmpty(temp0)) elements.Add(temp0);
                        if (!string.IsNullOrEmpty(temp1)) elements.Add(temp1);
                        if (!string.IsNullOrEmpty(temp2)) elements.Add(temp2);

                        if (elements.Count == 4)
                        {
                            if (int.TryParse(elements[3], out int idElement))
                            {
                                personModel = new PersonModel
                                {
                                    FirstName = elements[0],
                                    Lastname = elements[1],
                                    City = elements[2],
                                    Id = idElement
                                };

                                ExtractZipFromCity(ref personModel);
                                records.Add(personModel);
                            }

                            elements.Clear();
                        }

                        continue;
                    }

                    elements.Clear();
                    personModel = csv.GetRecord<PersonModel>();
                    ExtractZipFromCity(ref personModel);

                    records.Add(personModel);
                }

                return records;
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
            using var sw = new StreamWriter(Path, false, new UTF8Encoding(true));
            using var cw = new CsvWriter(sw, System.Globalization.CultureInfo.InvariantCulture);
            cw.Configuration.Delimiter = ", ";

            foreach (var person in personModels)
            {
                cw.WriteRecord<PersonModel>(person);
                cw.NextRecord();
            }
        }
    }
}
