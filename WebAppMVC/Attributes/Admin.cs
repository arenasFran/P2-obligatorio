using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppMVC.Attributes {
  public class Admin : Attribute, IAuthorizationFilter {
    public void OnAuthorization(AuthorizationFilterContext context) {
      if (context.HttpContext.Session.GetString("rol") != "Admin") {
        context.Result = new RedirectResult("/Publicaciones");
      }
    }
  }
}