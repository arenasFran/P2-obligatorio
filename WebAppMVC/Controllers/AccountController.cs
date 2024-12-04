using Microsoft.AspNetCore.Mvc;
using BibliotecaClases;
using BibliotecaClases.Personas;
using WebAppMVC.Attributes;
namespace WebAppMVC.Controllers;

public class AccountController : BaseController
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        try
        {
            Usuario usuario = Sistema.Instancia.Login(email, password);
            Console.WriteLine(usuario.Email);

            SetUserSession(usuario);

            if (usuario.Rol == "Admin")
            {
                return RedirectToAction("Subastas", "Admin"); 
            }

            return RedirectToAction("Index", "Publicaciones"); 
        }
        catch (Exception ex)
        {
            TempData["MensajeError"] = ex.Message;
            return View();
        }
    }


    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string email, string password, string firstName, string lastName)
    {
        try{
            Cliente? nuevoUsuario = Sistema.Instancia.RegistrarCliente(email, password, firstName, lastName);

            if (nuevoUsuario != null)
            {
                SetUserSession(nuevoUsuario);
                return RedirectToAction("Index", "Publicaciones");
            }

            return View();
        }catch(Exception ex) {
            TempData["MensajeError"] = ex.Message;
            return View();
        }
    }


    [HttpPost]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Account");
    }

    [Authenticate]
    public IActionResult Index()
    {
        Usuario? usuario = Sistema.Instancia.ObtenerUsuarioPorId(HttpContext.Session.GetInt32("id") ?? -1);

        if (usuario != null)
        {
            ViewBag.Nombre = usuario.Nombre;
            ViewBag.Email = usuario.Email;
            ViewBag.Rol = usuario.Rol;

            if (usuario is Cliente)
            {
                ViewBag.Saldo = (usuario as Cliente).Saldo;
            }
        }

        return View();
    }


    [HttpPost, Authenticate]
    public IActionResult CargarSaldo(double monto) {
        Usuario? usuario = Sistema.Instancia.ObtenerUsuarioPorId(HttpContext.Session.GetInt32("id") ?? -1);

        if (usuario is Cliente)
        {
            (usuario as Cliente).SumarSaldo(monto);
        }

        return RedirectToAction("Index");
    }
}
