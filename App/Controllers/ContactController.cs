using App.Filters;
using App.Helper;
using App.Models;
using App.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [PageForUserLogged]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly ISection _section;
        public ContactController(IContactRepository contactRepository, ISection section)
        {
            _contactRepository = contactRepository;
            _section = section;
        }
        public IActionResult Index()
        {
            UserModel userLogged = _section.GetUserSection();
            List<ContactModel> contacts = _contactRepository.GetAll(userLogged.IdUser);
            
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
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel userLogged = _section.GetUserSection();
                    contact.UserId = userLogged.IdUser;

                    contact = _contactRepository.Create(contact);
                    TempData["MessageSucess"] = "Contato cadastrado com sucesso!";

                    return RedirectToAction("Index");
                }

                return View("Create", contact);
            }
            catch (Exception ex)
            {
                TempData["MessageErr"] = $"Erro ao cadastrar, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Put(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel userLogged = _section.GetUserSection();
                    contact.UserId = userLogged.IdUser;

                    contact = _contactRepository.Update(contact);
                    TempData["MessageSucess"] = "Contato atualizado com sucesso!";

                    return RedirectToAction("Index");
                }

                return View("Update", contact);
            }
            catch (Exception ex)
            {
                TempData["MessageErr"] = $"Erro ao atualizar, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Delete(int id) 
        {
            try
            {
                bool delete = _contactRepository.Delete(id);

                if(delete)
                {
                    TempData["MessageSucess"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MessageErr"] = "Erro ao apagar!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MessageErr"] = $"Erro ao apagar, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
