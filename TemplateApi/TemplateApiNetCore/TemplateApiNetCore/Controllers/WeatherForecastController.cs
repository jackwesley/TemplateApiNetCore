using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TemplateApiNetCore.Controllers
{
    [Route("api/weather")]
    public class WeatherForecastController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get-weather")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("get-custom-response")]
        public IActionResult GetCustomResponse()
        {
            var rng = new Random();

            return CustomResponse(rng);
            //Em caso de erros vindo de um result 
            // foreach(errors in result.Errors)
            // {
            //  AddProcessingError(errors.Description)
            //}
            // return CustomResponse();
            //


            // Para Caso de ModelState Invalido faça
            // return CustomResponse(ModelState)
        }

    }
}
