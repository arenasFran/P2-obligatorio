using Microsoft.AspNetCore.Mvc;
using BibliotecaClases.Personas;

namespace WebAppMVC.Controllers;

public class BaseController : Controller
{
    protected void SetUserSession(Usuario usuario)
    {
        HttpContext.Session.SetString("email", usuario.Email);
        HttpContext.Session.SetString("nombre", usuario.Nombre + " " + usuario.Apellido);
        HttpContext.Session.SetString("rol", usuario.Rol);
        HttpContext.Session.SetInt32("id", usuario.Id);
    }
} 