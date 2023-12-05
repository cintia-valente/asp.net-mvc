using App.Models;
using Newtonsoft.Json;

namespace App.Helper
{
    public class Section : ISection
    {
        private readonly IHttpContextAccessor _httpContext;

        public Section(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public void CreateUserSection(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);

            _httpContext.HttpContext.Session.SetString("sessionUserLogged", value);
        }

        public UserModel GetUserSection()
        {
            string sessionUser = _httpContext.HttpContext.Session.GetString("sessionUserLogged");

            if (string.IsNullOrEmpty(sessionUser)) return null;

            return JsonConvert.DeserializeObject<UserModel>(sessionUser);
        }

        public void RemoveUserSectionn()
        {
            _httpContext.HttpContext.Session.Remove("sessionUserLogged");
        }
    }
}
