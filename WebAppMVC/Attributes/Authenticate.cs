using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppMVC.Attributes {
  public class Authenticate : Attribute, IAuthorizationFilter {
    public void OnAuthorization(AuthorizationFilterContext context) {
      if (context.HttpContext.Session.GetString("email") == null) {
        context.Result = new RedirectResult("/Account/Login");
      }
    }
  }
}