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
    public class EducateurController : Controller
    {
        /// <summary>
        /// page principale
        /// </summary>
        /// <returns></returns>
        [Route("Educateur")]
        [Route("Educateur/Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            JsonValue listeEducateursJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Educateur/ObtenirListeEducateur");
            ViewBag.listeEducateurs =JsonConvert.DeserializeObject<List<EducateurDTO>>(listeEducateursJson.ToString()).ToArray();
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        [Route("Educateur/AjouterEducateur")]
        [HttpPost]
        public async Task<IActionResult> AjouterEducateur([FromForm] EducateurDTO garderieDTO)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Educateur/AjouterEducateur", garderieDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Educateur");
        }

        /// <summary>
        /// Méthode de service appelé lors de l'action modifier.
        /// Rôles de l'action : 
        ///  -Lancer le formulaire Modifier
        /// </summary>
        /// <param name="nomEducateur">le nom de la Educateur a modifier</param>
        /// <returns></returns>
        [Route("Educateur/FormModifier")]
        [HttpGet]
        public async Task<IActionResult> FormModifier([FromQuery] string infos)
        {
            try
            {
                string[] parsedInfos = infos.Split("&"); 

                string Prenom = parsedInfos[1];
                string Nom = parsedInfos[0];
                string Date = parsedInfos[2];

                EducateurDTO educateur = new EducateurDTO(Nom, Prenom, Date);

                if (TempData["MessageErreur"] != null)
                    ViewBag.MessageErreur = TempData["MessageErreur"];

                JsonValue jsonResponse = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Educateur/ObtenirEducateur?nomEducateur=" + educateur.Nom + "&prenomEducateur=" + educateur.Prenom + "&dateNaissance=" + educateur.DateNaissance);
                EducateurDTO educateurBD = JsonConvert.DeserializeObject<EducateurDTO>(jsonResponse.ToString());

                return View(educateurBD);
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
        ///  -Modifier un Educateur
        /// </summary>
        /// <param name="garderie">la Educateur a modifier</param>
        /// <returns></returns>
        [Route("Educateur/ModifierEducateur")]
        [HttpPost]
        public async Task<IActionResult> ModifierEducateur([FromForm] EducateurDTO educateurDTO)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Educateur/ModifierEducateur", educateurDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index");
        }

        [Route("Educateur/SupprimerEducateur")]
        [HttpPost]
        public async Task<IActionResult> SupprimerEducateur([FromForm] string infos)
        {
            try
            {
                string[] parsedInfos = infos.Split("&"); 

                string Nom = parsedInfos[0];
                string Prenom = parsedInfos[1];
                string Date = parsedInfos[2];

                EducateurDTO educateurDTO = new EducateurDTO(Nom, Prenom, Date);

                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Educateur/SupprimerEducateur", educateurDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Educateur");
        }

        [Route("Educateur/ViderListeEducateur")]
        [HttpPost]
        public async Task<IActionResult> ViderListeEducateur()
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Educateur/ViderListeEducateur", null);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Educateur");
        }
    }
}
