using App.Filters;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [PageForUserLogged]
    public class RestrictedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
