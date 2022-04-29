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
        /// <summary>
        /// Obtenir la liste des depenses
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie associée avec les dépenses</param>
        /// <returns></returns>
        [Route("Depense")]
        [Route("Depense/Index")]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string nomGarderie)
        {
            try
            {
                JsonValue listeGarderiesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Garderie/ObtenirListeGarderie");
                ViewBag.listeGarderies = JsonConvert.DeserializeObject<List<GarderieDTO>>(listeGarderiesJson.ToString()).ToArray();
                if (nomGarderie == null)
                {
                    if (ViewBag.listeGarderies == null)
                    {
                        ViewBag.MessageErreur = "Pas de garderies, veuillez ajouter une garderie";
                    }
                    else
                    {
                        nomGarderie = ViewBag.listeGarderies[0].Nom;
                    }
                }
                JsonValue listeCategoriesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/CategorieDepense/ObtenirListeCategorieDepense");
                ViewBag.listeCategorieDepenses = JsonConvert.DeserializeObject<List<CategorieDepenseDTO>>(listeCategoriesJson.ToString()).ToArray();

                JsonValue listeCommercesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Commerce/ObtenirListeCommerce");
                ViewBag.listeCommerces = JsonConvert.DeserializeObject<List<CommerceDTO>>(listeCommercesJson.ToString()).ToArray();

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

        /// <summary>
        /// Permet d'ajouter une dépense
        /// </summary>
        /// <param name="nomGarderie">le nom de la garderie</param>
        /// <param name="depenseDTO">Le DTO de la dépense à ajouter</param>
        /// <returns></returns>
        [Route("Depense/AjouterDepense")]
        [HttpPost]
        public async Task<IActionResult> AjouterDepense([FromForm] string nomGarderie, [FromForm] DepenseDTO depenseDTO)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Depense/AjouterDepense?nomGarderie=" + nomGarderie, depenseDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Depense", new { nomGarderie = nomGarderie });
        }

        /// <summary>
        /// Permet de supprimer une dépense
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie</param>
        /// <param name="DateTemps">Le DateTime de la depense</param>
        /// <returns></returns>
        [Route("Depense/SupprimerDepense")]
        [HttpPost]
        public async Task<IActionResult> SupprimerDepense([FromForm] string nomGarderie, [FromForm] DateTime DateTemps)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Depense/SupprimerDepense?nomGarderie=" + nomGarderie + "&DateTemps=" + DateTemps, null);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Depense", new { nomGarderie = nomGarderie });
        }

        /// <summary>
        /// Permet de rediriger vers la page de modification d'une dépense
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie</param>
        /// <param name="DateTemps">Le DateTime de la depense</param>
        /// <returns></returns>
        [Route("Depense/FormModifierDepense")]
        [HttpGet]
        public async Task<IActionResult> FormModifierDepense([FromQuery] string nomGarderie, [FromQuery] string DateTemps)
        {
            try
            {
                ViewBag.nomGarderie = nomGarderie;
                JsonValue DepenseJSON = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Depense/ObtenirDepense?nomGarderie=" + nomGarderie + "&dateTemps=" + DateTemps);
                DepenseDTO depenseDTO = JsonConvert.DeserializeObject<DepenseDTO>(DepenseJSON.ToString());

                JsonValue listeCategoriesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/CategorieDepense/ObtenirListeCategorieDepense");
                ViewBag.listeCategorieDepenses = JsonConvert.DeserializeObject<List<CategorieDepenseDTO>>(listeCategoriesJson.ToString()).ToArray();

                JsonValue listeCommercesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Commerce/ObtenirListeCommerce");
                ViewBag.listeCommerces = JsonConvert.DeserializeObject<List<CommerceDTO>>(listeCommercesJson.ToString()).ToArray();

                return View(depenseDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return View();
        }

        /// <summary>
        /// Permet de modifier une dépense
        /// </summary>
        /// <param name="depenseDTO">La dépense à modifier</param>
        /// <param name="nomGarderie">Le nom de la garderie à laquelle la dépense appartient</param>
        /// <returns></returns>
        [Route("Depense/ModifierDepense")]
        [HttpPost]
        public async Task<IActionResult> ModifierDepense([FromForm] DepenseDTO depenseDTO, [FromForm] string nomGarderie)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Depense/ModifierDepense?nomGarderie=" + nomGarderie, depenseDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Depense", new { nomGarderie = nomGarderie });
        }
    }
}