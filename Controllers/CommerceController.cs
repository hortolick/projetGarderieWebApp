using Microsoft.AspNetCore.Mvc;

namespace projetGarderieWebApp.Controllers
{
    public class CommerceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
