using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Laboratorio_19._3.Controllers
{
    public class ConsumoController : Controller
    {
        // GET: Consumo

        private readonly string urlAPI = "https://localhost:44380/api/Values/Get/2";
        public async Task<ActionResult> PorId()
        {
            using (HttpClient client = new HttpClient())
            {

                var respuesta = await client.GetAsync(urlAPI);
                var json = await respuesta.Content.ReadAsStringAsync();
                var contenido = JsonConvert.DeserializeObject<string>(json);
                return View((object)contenido);

            }
        }
    }
}