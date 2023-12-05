using App.Filters;
using App.Models;
using App.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [PageRestrictedAdminOnly]
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

        public IActionResult Update(int id)
        {
            UserModel user = _userRepository.GetForId(id);

            return View(user);
        }

        public IActionResult Remove(int id)
        {
            UserModel user = _userRepository.GetForId(id);

            return View(user);
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

        [HttpPost]
        public IActionResult Put(UserNoPasswordModel userNoPasswordModel)
        {
            try
            {
                UserModel userModel = null;
                if (ModelState.IsValid)
                {
                    userModel = new UserModel()
                    {
                        IdUser = userNoPasswordModel.IdUser,
                        Name = userNoPasswordModel.Name,
                        Login = userNoPasswordModel.Login,
                        Email = userNoPasswordModel.Email,
                        Profile = userNoPasswordModel.Profile
                    };

                    _userRepository.Update(userModel);
                    TempData["MessageSucess"] = "Usuário atualizado com sucesso!";

                    return RedirectToAction("Index");
                }

                return View("Update", userModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["MessageErr"] = $"Erro ao atualizar, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool delete = _userRepository.Delete(id);

                if (delete) TempData["MessageSucess"] = "Usuário apagado com sucesso!"; else TempData["MessageErr"] = "Erro ao apagar!";
                
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
