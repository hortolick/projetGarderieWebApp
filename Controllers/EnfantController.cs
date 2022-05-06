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
    public class EnfantController : Controller
    {
        /// <summary>
        /// page principale
        /// </summary>
        /// <returns></returns>
        [Route("Enfant")]
        [Route("Enfant/Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            JsonValue listeEnfantsJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Enfant/ObtenirListeEnfant");
            ViewBag.listeEnfants =JsonConvert.DeserializeObject<List<EnfantDTO>>(listeEnfantsJson.ToString()).ToArray();
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        [Route("Enfant/AjouterEnfant")]
        [HttpPost]
        public async Task<IActionResult> AjouterEnfant([FromForm] EnfantDTO garderieDTO)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Enfant/AjouterEnfant", garderieDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Enfant");
        }

        /// <summary>
        /// Méthode de service appelé lors de l'action modifier.
        /// Rôles de l'action : 
        ///  -Lancer le formulaire Modifier
        /// </summary>
        /// <param name="nomEnfant">le nom de la Enfant a modifier</param>
        /// <returns></returns>
        [Route("Enfant/FormModifier")]
        [HttpGet]
        public async Task<IActionResult> FormModifier([FromQuery] string infos)
        {
            try
            {
                string[] parsedInfos = infos.Split("&"); 

                string Prenom = parsedInfos[1];
                string Nom = parsedInfos[0];
                string Date = parsedInfos[2];

                EnfantDTO enfant = new EnfantDTO(Nom, Prenom, Date);

                if (TempData["MessageErreur"] != null)
                    ViewBag.MessageErreur = TempData["MessageErreur"];

                JsonValue jsonResponse = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Enfant/ObtenirEnfant?nomEnfant=" + enfant.Nom + "&prenomEnfant=" + enfant.Prenom + "&dateNaissance=" + enfant.DateNaissance);
                EnfantDTO enfantBD = JsonConvert.DeserializeObject<EnfantDTO>(jsonResponse.ToString());

                return View(enfantBD);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return View();
        }


        /// <summary>
        /// Méthode de service appelé lors de l'action modifier.
        /// Rôles de l'action : 
        ///  -Modifier un Enfant
        /// </summary>
        /// <param name="garderie">la Enfant a modifier</param>
        /// <returns></returns>
        [Route("Enfant/ModifierEnfant")]
        [HttpPost]
        public async Task<IActionResult> ModifierEnfant([FromForm] EnfantDTO enfantDTO)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Enfant/ModifierEnfant", enfantDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index");
        }

        [Route("Enfant/SupprimerEnfant")]
        [HttpPost]
        public async Task<IActionResult> SupprimerEnfant([FromForm] string infos)
        {
            try
            {
                string[] parsedInfos = infos.Split("&"); 

                string Nom = parsedInfos[0];
                string Prenom = parsedInfos[1];
                string Date = parsedInfos[2];

                EnfantDTO enfantDTO = new EnfantDTO(Nom, Prenom, Date);

                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Enfant/SupprimerEnfant", enfantDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Enfant");
        }

        [Route("Enfant/ViderListeEnfant")]
        [HttpPost]
        public async Task<IActionResult> ViderListeEnfant()
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Enfant/ViderListeEnfant", null);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Enfant");
        }
    }
}
