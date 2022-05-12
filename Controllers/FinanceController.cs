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
        public async Task<IActionResult> Index([FromQuery] int annee, [FromQuery] string nomGarderie)
        {
            try
            {
                if (annee == 0)
                {
                    annee = DateTime.Now.Year;
                }
                JsonValue listeGarderiesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Garderie/ObtenirListeGarderie");
                ViewBag.listeGarderies = JsonConvert.DeserializeObject<List<GarderieDTO>>(listeGarderiesJson.ToString()).ToArray();
                if (nomGarderie == null)
                {
                    nomGarderie = ViewBag.listeGarderies[0].Nom;
                }

                ViewBag.nomGarderie = nomGarderie;
                ViewBag.annee = annee;

                //JsonValue listeFinanceJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Finance/ObtenirFinance?annee=" + annee + "&nomGarderie=" + nomGarderie);
                return View();
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
