using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private Dictionary<int,string> dictionary = new Dictionary<int, string>() 
        {
            { 1, "blau"}, { 2, "grün"}, { 3, "violett"},{ 4, "rot"}, { 5, "gelb"}, { 6, "türkis"}, { 7, "weiß"}
        };

        public WeatherForecastController(IParserService iParserService)
        {
            IParserService = iParserService;

            var result = IParserService.ReadCsvFileToEmployeeModel();
        }        

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {        
            var result = IParserService.ReadCsvFileToEmployeeModel();


            return null;
        }
    }
}
