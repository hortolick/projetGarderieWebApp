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
        [Route("Depense")]
        [Route("Depense/Index")]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]string nomGarderie)
        {
            try
            {
                JsonValue listeGarderiesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Garderie/ObtenirListeGarderie");
                ViewBag.listeGarderies = JsonConvert.DeserializeObject<List<GarderieDTO>>(listeGarderiesJson.ToString()).ToArray();
                if(nomGarderie == null)
                {
                    if(ViewBag.listeGarderies == null)
                    {
                        ViewBag.MessageErreur = "Pas de garderies, veuillez ajouter une garderie";
                    }
                    else{
                        nomGarderie = ViewBag.listeGarderies[0].Nom;
                    }
                }
                JsonValue listeCategoriesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Categorie/ObtenirListeCategorie");
                ViewBag.listeCategories = JsonConvert.DeserializeObject<List<CategorieDepenseDTO>>(listeCategoriesJson.ToString()).ToArray();

                JsonValue listeCommercesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Commerce/ObtenirListeCommerce");
                ViewBag.listeCommerces = JsonConvert.DeserializeObject<List<CategorieDepenseDTO>>(listeCommercesJson.ToString()).ToArray();

                JsonValue listeDepensesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Depense/ObtenirListeDepense?nomGarderie=" + nomGarderie);
                ViewBag.listeDepenses = JsonConvert.DeserializeObject<List<DepenseDTO>>(listeDepensesJson.ToString()).ToArray();
                ViewBag.nomGarderie = nomGarderie;
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
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
