using App.Models;
using App.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post (LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine("Login attempt: " + login.Login);

                    UserModel user = _userRepository.GetForLogin(login.Login);

                    if (user != null)
                    {
                        if (user.PasswordValid(login.Password))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MessageErr"] = $"Senha inválida. Por favor, tente novamente.";
                    }

                    TempData["MessageErr"] = $"Usuário ou senha inválidos. Por favor, tente novamente.";
                }

                return View("Index");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["MessageErr"] = $"Erro ao cadastrar, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
