using App.Helper;
using App.Models;
using App.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISection _section;
        public LoginController(IUserRepository userRepository, ISection section)
        {
            _userRepository = userRepository;
            _section = section;
        }
        public IActionResult Index()
        {
            if (_section.GetUserSection() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult RedefinePassword()
        {
            return View();
        }

        public IActionResult Exit()
        {
            _section.RemoveUserSectionn();

            return RedirectToAction("Index", "Login");
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
                            _section.CreateUserSection(userModel);
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

        //[HttpPost] 
        //public IActionResult SendLinkToResetPassword (RedefinePasswordModel redefinePassword)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            UserModel userModel = _userRepository.GetForEmailAndLogin(redefinePassword.Email, redefinePassword.Login);

        //            if (userModel != null)
        //            {
        //                //string newPassword = userModel.GenerateNewPassword();
        //                //string message = $"Sua nova senha é: {newPassword}";

        //                //bool emailSent = _email.Send(userModel.Email, "Sistema de Contatos - Nova Senha", message);

        //                //if (emailSent)
        //                //{
        //                //    _userRepository.Update(userModel);

        //                //    TempData["MessageSucess"] = $"Enviamos para seu email cadastrado uma nova senha.";
        //                //}
        //                //else
        //                //{
        //                //    TempData["MessageErr"] = $"Ops, não conseguimos enviar o email. Por favor, tente novamente.";
        //                //}

        //                return RedirectToAction("Index", "Login");
        //            }

        //            TempData["MessageErr"] = $"Ops, não conseguimos redefinir sua senha. Por favor, verifique os dados informados.";
        //        }

        //        return View("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["MessageErr"] = $"Erro ao apagar, tente novamente, detalhe do erro: {ex.Message}";
        //        return RedirectToAction("Index");
        //    }
        //}
    }
}
