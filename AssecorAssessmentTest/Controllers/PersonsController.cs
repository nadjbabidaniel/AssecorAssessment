using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AssecorAssessmentTest.Model;
using AssecorAssessmentTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AssecorAssessmentTest.Controllers
{
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IParserService IParserService { get; }
        private List<PersonModel> Results { get; set; }
        private static readonly Dictionary<int, string> Dictionary = new Dictionary<int, string>()
        {
            { 1, "blau"}, { 2, "grün"}, { 3, "violett"},{ 4, "rot"}, { 5, "gelb"}, { 6, "türkis"}, { 7, "weiß"}
        };

        public PersonsController(IParserService iParserService)
        {
            IParserService = iParserService;

            Results = IParserService.ReadCsvFileToEmployeeModel();

            UpdateColor(Results);
        }

        private void UpdateColor(List<PersonModel> results)
        {
            foreach (var person in results)
            {
                person.Color = Dictionary[person.Id];
            }
        }

        [HttpGet]
        [Route("persons")]
        public string GetPersons()
        {
            return JsonSerializer.Serialize(Results);
        }

        [HttpGet]
        [Route("persons/{id?}")]
        public string GetPerson(int Id)
        {
            return JsonSerializer.Serialize(Results.FindAll(x => x.Id == Id).ToList());
        }

        [HttpGet]
        [Route("/persons/color/{color}")]
        public string GetColor(string color)
        {
            return JsonSerializer.Serialize(Results.FindAll(x => x.Color.Equals(color)).ToList());
        }

        [HttpPost]
        [Route("persons")]
        public void InsertPerson([FromBody] List<PersonModel> personModels)
        {
            try
            {
                IParserService.WriteNewCsvFile(personModels);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
