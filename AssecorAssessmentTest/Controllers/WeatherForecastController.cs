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
        public IParserService IParserService { get; }

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
