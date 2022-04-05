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
    public class DepenseController : Controller
    {
        [Route("")]
        [Route("Depense")]
        [Route("Depense/Index")]
        [HttpGet]
        public async Task<IActionResult> Index(string nomGarderie)
        {
            JsonValue listeGarderiesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Garderie/ObtenirListeGarderie");
            ViewBag.listeGarderies = JsonConvert.DeserializeObject<List<GarderieDTO>>(listeGarderiesJson.ToString()).ToArray();
            JsonValue listeDepensesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Depense/ObtenirListeDepense");
            ViewBag.listeDepenses = JsonConvert.DeserializeObject<List<DepenseDTO>>(listeDepensesJson.ToString()).ToArray();
            return View();
        }

        [Route("Depense/AjouterDepense")]
        [HttpPost]
        public async Task<IActionResult> AjouterDepense([FromForm] string nomGarderie ,[FromForm] DepenseDTO depenseDTO)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Depense/AjouterDepense?nomGarderie=" + nomGarderie, depenseDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Depense");
        }
    }
}
