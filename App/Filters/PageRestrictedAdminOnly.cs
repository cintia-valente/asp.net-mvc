using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace App.Filters
{
    public class PageRestrictedAdminOnly : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sectionUser = context.HttpContext.Session.GetString(("sessionUserLogged"));

            if (string.IsNullOrEmpty(sectionUser))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }

            UserModel user = JsonConvert.DeserializeObject<UserModel>(sectionUser); 

            if (user.Profile != Enums.ProfileEnum.Admin)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restricted" }, { "action", "Index" } });
            }

            base.OnActionExecuting(context);
        }
    }
}
