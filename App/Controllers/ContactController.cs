using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Put()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
