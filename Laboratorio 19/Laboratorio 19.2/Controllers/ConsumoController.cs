using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Laboratorio_19._2.Controllers
{
    public class ConsumoController : Controller
    {
        // GET: Consumo

        private readonly string urlAPI = "https://localhost:44380/api/Values/Get";
        public async Task<ActionResult> Todos()
        {
            using (HttpClient client = new HttpClient())
            {

                var respuesta = await client.GetAsync(urlAPI);
                var json = await respuesta.Content.ReadAsStringAsync();
                var contenido = JsonConvert.DeserializeObject<List<string>>(json);
                return View(contenido);

            }
        }
    }
}