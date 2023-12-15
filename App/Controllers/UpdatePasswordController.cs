using App.Helper;
using App.Models;
using App.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class UpdatePasswordController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISection _section;
        public UpdatePasswordController(IUserRepository userRepository, ISection section)
        {
            _userRepository = userRepository;
            _section = section;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Put(UpdatePasswordModel updatePasswordModel)
        {
            try
            {
                  UserModel userlogged = _section.GetUserSection();
                updatePasswordModel.Id = userlogged.IdUser;

                if (ModelState.IsValid)
                {
                    _userRepository.UpdatePassword(updatePasswordModel);
                    TempData["MessageSucess"] = "Senha alterada com sucesso!";

                    return View("Index", updatePasswordModel);
                }

                return View("Index", updatePasswordModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                TempData["MessageErr"] = $"Erro ao alterar a senha, tente novamente, detalhe do erro: {ex.Message}";
                return View("Index", updatePasswordModel);
            }
            return View();
        }
    }
}
