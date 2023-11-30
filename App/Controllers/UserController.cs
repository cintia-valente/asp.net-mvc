using App.Models;
using App.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.GetAll();

            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Create(user);
                    TempData["MessageSucess"] = "Usuário cadastrado com sucesso!";

                    return RedirectToAction("Index");
                }

                return View("Create", user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["MessageErr"] = $"Erro ao cadastrar, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
