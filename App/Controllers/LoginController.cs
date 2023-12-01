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
        public IActionResult Enter(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel userModel = _userRepository.GetForLogin(loginModel.Login);
                    
                    if (userModel != null) 
                    {
                        if (userModel.PasswordValid(loginModel.Password))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MessageErr"] = $"Senha inválida, por favor tente novamente.";
                    }

                    TempData["MessageErr"] = $"Usuário ou senha inválidos, por favor tente novamente.";
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MessageErr"] = $"Erro ao apagar, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
