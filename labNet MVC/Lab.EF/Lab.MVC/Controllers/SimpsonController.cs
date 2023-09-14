using Lab.MVC.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class SimpsonController : Controller
    {
        // GET: Simpson
        public async Task<ActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                var cliente = new HttpClient();
                var json = await cliente.GetStringAsync("https://apisimpsons.fly.dev/api/personajes");
                var response = JsonConvert.DeserializeObject<ResponseContainer>(json);
                List<SimpsonView> simpsons = response.Docs;

                return View(simpsons);
            }
        }
    }
}