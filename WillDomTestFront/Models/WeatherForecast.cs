using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillDomTestFront.Models
{
    public class WeatherForecast
    {
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "TemperatureC")]
        public int TemperatureC { get; set; }

        [Display(Name = "TemperatureF")]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [Display(Name = "Summary")]
        public string Summary { get; set; }
    }
}
