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
            List<ContactModel> contacts = _contactRepository.GetAll();
            
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            ContactModel contact = _contactRepository.GetForId(id);
            
            return View(contact);
        }

        public IActionResult Remove(int id)
        {
            ContactModel contact = _contactRepository.GetForId(id);

            return View(contact);
        }

        [HttpPost]
        public IActionResult Post(ContactModel contact) 
        {
            _contactRepository.Create(contact);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Put(ContactModel contact)
        {
            _contactRepository.Update(contact);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            _contactRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
