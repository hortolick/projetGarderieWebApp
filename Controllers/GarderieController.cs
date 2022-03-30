using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using projetGarderieWebApp.DTOs;
using projetGarderieWebApp.Tools;
using System;
using System.Collections.Generic;
using System.Json;
using System.Threading.Tasks;

namespace projetGarderieWebApp.Controllers
{
    public class GarderieController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [Route("Garderie")]
        [Route("Garderie/Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            JsonValue listeGarderiesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Garderie/ObtenirListeGarderie");
            ViewBag.listeGarderies =JsonConvert.DeserializeObject<List<GarderieDTO>>(listeGarderiesJson.ToString()).ToArray();
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        [Route("Garderie/AjouterGarderie")]
        [HttpGet]
        public async Task<IActionResult> AjouterGarderie([FromForm] GarderieDTO garderie)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Garderie/AjouterGarderie", garderie);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Garderie");
        }

        /// <summary>
        /// Méthode de service appelé lors de l'action modifier.
        /// Rôles de l'action : 
        ///  -Lancer le formulaire Modifier
        /// </summary>
        /// <param name="nomGarderie">le nom de la Garderie a modifier</param>
        /// <returns></returns>
        [Route("Garderie/FormModifier")]
        [HttpGet]
        public async Task<IActionResult> FormModifier([FromQuery] string nomGarderie)
        {
            try
            {
                if (TempData["MessageErreur"] != null)
                    ViewBag.MessageErreur = TempData["MessageErreur"];
                JsonValue jsonResponse = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Garderie/ObtenirGarderie?nomGarderie=" + nomGarderie);
                GarderieDTO garderie = JsonConvert.DeserializeObject<GarderieDTO>(jsonResponse.ToString());
                return View(garderie);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Méthode de service appelé lors de l'action modifier.
        /// Rôles de l'action : 
        ///  -Modifier un Garderie
        /// </summary>
        /// <param name="garderie">la Garderie a modifier</param>
        /// <returns></returns>
        [Route("Garderie/ModifierGarderie")]
        [HttpPost]
        public async Task<IActionResult> ModifierGarderie([FromForm] GarderieDTO garderie)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Garderie/ModifierGarderie", garderie);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index");
        }

        [Route("Garderie/SupprimerGarderie")]
        [HttpPost]
        public async Task<IActionResult> SupprimerGarderie([FromForm] string nomGarderie)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Garderie/SupprimerGarderie?nomGarderie=" + nomGarderie, null);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Garderie");
        }

        [Route("Garderie/ViderListeGarderie")]
        [HttpPost]
        public async Task<IActionResult> ViderListeGarderie()
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Garderie/ViderListeGarderie", null);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Garderie");
        }
    }
}
