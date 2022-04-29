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
    public class CategorieDepenseController : Controller
    {
        /// <summary>
        /// page principale
        /// </summary>
        /// <returns></returns>
        [Route("CategorieDepense")]
        [Route("CategorieDepense/Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            JsonValue listeCategorieDepensesJson = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/CategorieDepense/ObtenirListeCategorieDepense");
            ViewBag.listeCategorieDepenses =JsonConvert.DeserializeObject<List<CategorieDepenseDTO>>(listeCategorieDepensesJson.ToString()).ToArray();
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        [Route("CategorieDepense/AjouterCategorieDepense")]
        [HttpPost]
        public async Task<IActionResult> AjouterCategorieDepense([FromForm] CategorieDepenseDTO garderieDTO)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/CategorieDepense/AjouterCategorieDepense", garderieDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "CategorieDepense");
        }



        /// <summary>
        /// Méthode de service appelé lors de l'action modifier.
        /// Rôles de l'action : 
        ///  -Lancer le formulaire Modifier
        /// </summary>
        /// <param name="nomCategorieDepense">le nom de la CategorieDepense a modifier</param>
        /// <returns></returns>
        [Route("CategorieDepense/FormModifier")]
        [HttpGet]
        public async Task<IActionResult> FormModifier([FromQuery] string descriptionCategorie)
        {
            try
            {
                if (TempData["MessageErreur"] != null)
                    ViewBag.MessageErreur = TempData["MessageErreur"];
                JsonValue jsonResponse = await WebAPI.Instance.ExecuteGetAsync("http://" + Program.HOST + ":" + Program.PORT + "/CategorieDepense/ObtenirCategorieDepense?descriptionCategorie=" + descriptionCategorie);
                CategorieDepenseDTO garderie = JsonConvert.DeserializeObject<CategorieDepenseDTO>(jsonResponse.ToString());
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
        ///  -Modifier un CategorieDepense
        /// </summary>
        /// <param name="">la CategorieDepense a modifier</param>
        /// <returns></returns>
        [Route("CategorieDepense/ModifierCategorieDepense")]
        [HttpPost]
        public async Task<IActionResult> ModifierCategorieDepense([FromForm] CategorieDepenseDTO categorieDepenseDTO)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/CategorieDepense/ModifierCategorieDepense", categorieDepenseDTO);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Méthode de service appelé lors de l'action supprimer.
        /// </summary>
        /// <param name="descriptionCategorie">La description de la catégorie à supprimer</param>
        /// <returns>À l'index de la categorie depense</returns>
        [Route("CategorieDepense/SupprimerCategorieDepense")]
        [HttpPost]
        public async Task<IActionResult> SupprimerCategorieDepense([FromForm] string descriptionCategorie)
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/CategorieDepense/SupprimerCategorieDepense?descriptionCategorie=" +descriptionCategorie, null);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "CategorieDepense");
        }

        /// <summary>
        /// Méthode de service appelé lors de l'action vider liste.
        /// </summary>
        /// <returns>À l'index de la categorie depense</returns>
        [Route("CategorieDepense/ViderListeCategorieDepense")]
        [HttpPost]
        public async Task<IActionResult> ViderListeCategorieDepense()
        {
            try
            {
                await WebAPI.Instance.PostAsync("http://" + Program.HOST + ":" + Program.PORT + "/CategorieDepense/ViderListeCategorieDepense", null);
            }
            catch (Exception e)
            {
                ViewBag.MessageErreur = e.Message;
            }
            return RedirectToAction("Index", "CategorieDepense");
        }
    }
}
