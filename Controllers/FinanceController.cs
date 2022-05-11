using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using projetGarderieWebApp.Models;
using projetGarderieWebApp.Tools;
using System;
using System.Collections.Generic;
using System.Json;
using System.Threading.Tasks;

namespace projetGarderieWebApp.Controllers
{
    public class FinanceController : Controller
    {
        [Route("Finance")]
        [Route("Finance/Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                JsonValue listeGarderiesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Garderie/ObtenirListeGarderie");
                ViewBag.listeGarderies = JsonConvert.DeserializeObject<List<GarderieDTO>>(listeGarderiesJson.ToString()).ToArray();

                return View();
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
