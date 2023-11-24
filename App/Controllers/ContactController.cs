using App.Models;
using App.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository; 
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
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

        [HttpPost]
        public IActionResult Post(ContactModel contact) 
        {
            _contactRepository.Create(contact);

            return RedirectToAction("Index");
        }
    }
}
