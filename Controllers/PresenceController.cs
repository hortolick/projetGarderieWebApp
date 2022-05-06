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
    public class PresenceController : Controller
    {
        /// <summary>
        /// Obtenir la liste des presences
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie associée avec les presences</param>
        /// <returns></returns>
        [Route("Presence")]
        [Route("Presence/Index")]
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
                JsonValue listeEnfantsJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Enfant/ObtenirListeEnfant");
                ViewBag.listeEnfants = JsonConvert.DeserializeObject<List<EnfantDTO>>(listeEnfantsJson.ToString()).ToArray();

                JsonValue listePresencesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Presence/ObtenirListePresenceGarderie?nomGarderie=" + nomGarderie);
                ViewBag.listePresences = JsonConvert.DeserializeObject<List<PresenceDTO>>(listePresencesJson.ToString()).ToArray();
                ViewBag.nomGarderie = nomGarderie;
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return View();
        }

        /// <summary>
        /// Permet d'ajouter une presence
        /// </summary>
        /// <param name="infos">Les infos sur l'enfant selectionnes a partir du dropdown</param>
        /// <param name="presence">Le DTO de la presence à ajouter</param>
        /// <returns></returns>
        [Route("Presence/AjouterPresence")]
        [HttpPost]
        public async Task<IActionResult> AjouterPresence([FromForm] string infos, [FromForm] PresenceDTO presence)
        {
            string[] parsedInfos = infos.Split("&");

            string Prenom = parsedInfos[0];
            string Nom = parsedInfos[1];
            string Date = parsedInfos[2];

            EnfantDTO enfantDTO = new EnfantDTO(Nom, Prenom, Date);

            presence.Enfant = enfantDTO;


            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Presence/AjouterPresence?nomGarderie", presence);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Presence", new { nomGarderie = presence.NomGarderie });
        }

        /*
        /// <summary>
        /// Permet de supprimer une dépense
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie</param>
        /// <param name="DateTemps">Le DateTime de la depense</param>
        /// <returns></returns>
        [Route("Presence/SupprimerPresence")]
        [HttpPost]
        public async Task<IActionResult> SupprimerPresence([FromForm] string nomGarderie, [FromForm] DateTime DateTemps)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Presence/SupprimerPresence?nomGarderie=" + nomGarderie + "&DateTemps=" + DateTemps, null);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Presence", new { nomGarderie = nomGarderie });
        }

        /// <summary>
        /// Permet de rediriger vers la page de modification d'une dépense
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie</param>
        /// <param name="DateTemps">Le DateTime de la depense</param>
        /// <returns></returns>
        [Route("Presence/FormModifierPresence")]
        [HttpGet]
        public async Task<IActionResult> FormModifierPresence([FromQuery] string nomGarderie, [FromQuery] string DateTemps)
        {
            try
            {
                ViewBag.nomGarderie = nomGarderie;
                JsonValue PresenceJSON = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Presence/ObtenirPresence?nomGarderie=" + nomGarderie + "&dateTemps=" + DateTemps);
                PresenceDTO depenseDTO = JsonConvert.DeserializeObject<PresenceDTO>(PresenceJSON.ToString());

                JsonValue listeCategoriesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/CategoriePresence/ObtenirListeCategoriePresence");
                ViewBag.listeCategoriePresences = JsonConvert.DeserializeObject<List<CategoriePresenceDTO>>(listeCategoriesJson.ToString()).ToArray();

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
        [Route("Presence/ModifierPresence")]
        [HttpPost]
        public async Task<IActionResult> ModifierPresence([FromForm] PresenceDTO depenseDTO, [FromForm] string nomGarderie)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Presence/ModifierPresence?nomGarderie=" + nomGarderie, depenseDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Presence", new { nomGarderie = nomGarderie });
        }
        */
    }
}
