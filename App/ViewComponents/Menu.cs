using App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace App.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sectionUser = HttpContext.Session.GetString("sessionUserLogged");

            if (string.IsNullOrEmpty(sectionUser)) return null;

            UserModel user = JsonConvert.DeserializeObject<UserModel>(sectionUser);
            
            return View(user);
        }
    }
}
