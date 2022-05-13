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
        /// <summary>
        /// Get the list of all the finances
        /// </summary>
        /// <param name="annee">L'annee des finances</param>
        /// <param name="nomGarderie">Le nom de la garderie</param>
        /// <returns></returns>
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


                JsonValue listeFinanceJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Finance/ObtenirFinances?nomGarderie=" + nomGarderie + "&annee=" + annee);
                FinanceDTO finance = JsonConvert.DeserializeObject<FinanceDTO>(listeFinanceJson.ToString());

                ViewBag.Depense = finance.depense;
                ViewBag.Revenus = finance.revenu;
                ViewBag.Profit = finance.profit;

                return View();
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
