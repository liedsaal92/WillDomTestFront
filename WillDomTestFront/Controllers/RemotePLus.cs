using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WillDomTestFront.Models;

namespace WillDomTestFront.Controllers
{
    public class RemotePLus : Controller
    {
        public IActionResult Index()
        {
            string url = "https://localhost:44371/weatherforecast";
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            List<WeatherForecast> listaWheater = new List<WeatherForecast>();
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader != null)
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                listaWheater = JsonConvert.DeserializeObject<List<WeatherForecast>>(responseBody);
                            }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
            return View(listaWheater);
        }
    }
}
