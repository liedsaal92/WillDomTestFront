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
    public class Remote : Controller
    {
        public IActionResult Index(int page=1)
        {
            TempData["currentpage"] = page;
            string url = "https://gnews.io/api/v4/search?q=watches&token=a82a0a76c3412ea5cd4b5aee1ffd2225";
            var request = (HttpWebRequest)WebRequest.Create(url);
            int paginacion = 3;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            Watches listaArticulos = new Watches();
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
                            listaArticulos = JsonConvert.DeserializeObject<Watches>(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }

            int totalRegistro = paginacion * page;
            List<Articles> articulospaginados = new List<Articles>();
            int contador = 1;
            foreach (var item in listaArticulos.articles)
            {
                
                if (contador <= totalRegistro && contador>(totalRegistro - paginacion))
                {
                    articulospaginados.Add(item);
                }
                contador = contador + 1;
            }
            return View(articulospaginados);
        }
    }
}
