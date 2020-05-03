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
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IParserService IParserService { get; }
        private List<PersonModel> Results { get; set; }
        private readonly Dictionary<int, string> Dictionary = new Dictionary<int, string>()
        {
            { 1, "blau"}, { 2, "grün"}, { 3, "violett"},{ 4, "rot"}, { 5, "gelb"}, { 6, "türkis"}, { 7, "weiß"}
        };

        public WeatherForecastController(IParserService iParserService)
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
        public string GetPersons()
        {
            return JsonSerializer.Serialize(Results);            
        }
    }
}
