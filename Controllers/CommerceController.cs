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
    public class CommerceController : Controller
    {
        /// <summary>
        /// page principale
        /// </summary>
        /// <returns></returns>
        [Route("Commerce")]
        [Route("Commerce/Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            JsonValue listeCommercesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Commerce/ObtenirListeCommerce");
            ViewBag.listeCommerces =JsonConvert.DeserializeObject<List<CommerceDTO>>(listeCommercesJson.ToString()).ToArray();
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        [Route("Commerce/AjouterCommerce")]
        [HttpPost]
        public async Task<IActionResult> AjouterCommerce([FromForm] CommerceDTO garderieDTO)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Commerce/AjouterCommerce", garderieDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Commerce");
        }



        /// <summary>
        /// Méthode de service appelé lors de l'action modifier.
        /// Rôles de l'action : 
        ///  -Lancer le formulaire Modifier
        /// </summary>
        /// <param name="nomCommerce">le nom de la Commerce a modifier</param>
        /// <returns></returns>
        [Route("Commerce/FormModifier")]
        [HttpGet]
        public async Task<IActionResult> FormModifier([FromQuery] string descriptionCommerce)
        {
            try
            {
                if (TempData["MessageErreur"] != null)
                    ViewBag.MessageErreur = TempData["MessageErreur"];
                JsonValue jsonResponse = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/Commerce/ObtenirCommerce?descriptionCommerce=" + descriptionCommerce);
                CommerceDTO garderie = JsonConvert.DeserializeObject<CommerceDTO>(jsonResponse.ToString());
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
        ///  -Modifier un Commerce
        /// </summary>
        /// <param name="">la Commerce a modifier</param>
        /// <returns></returns>
        [Route("Commerce/ModifierCommerce")]
        [HttpPost]
        public async Task<IActionResult> ModifierCommerce([FromForm] CommerceDTO commerceDTO)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Commerce/ModifierCommerce", commerceDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index");
        }

        [Route("Commerce/SupprimerCommerce")]
        [HttpPost]
        public async Task<IActionResult> SupprimerCommerce([FromForm] string descriptionCommerce)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Commerce/SupprimerCommerce?descriptionCommerce=" +descriptionCommerce, null);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Commerce");
        }

        [Route("Commerce/ViderListeCommerce")]
        [HttpPost]
        public async Task<IActionResult> ViderListeCommerce()
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/Commerce/ViderListeCommerce", null);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "Commerce");
        }
    }
}
