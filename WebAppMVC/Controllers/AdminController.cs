using BibliotecaClases;
using BibliotecaClases.Negocio;
using BibliotecaClases.Personas;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Attributes;

namespace WebAppMVC.Controllers
{
    [Authenticate, Admin]
    public class AdminController : Controller
    {
        public IActionResult Subastas()
        {
            List<Subasta> subastas = Sistema.Instancia.FiltrarSubastas();

            // We need to sort by the fechaPublicacion
            subastas.Sort((a, b) => a.FechaPublicacion.CompareTo(b.FechaPublicacion));
       
            ViewBag.Subastas = subastas;
           
            return View();
        }

        [HttpPost]
        public IActionResult CerrarSubasta(int publicacionId)
        {
            try
            {
                Subasta? subastaEncontrada = Sistema.Instancia.ObtenerSubastaPorId(publicacionId);


                if (subastaEncontrada == null)
                {
                    throw new Exception("La subasta no se encontró");
                }
           
                int? adminId = HttpContext.Session.GetInt32("id");
                if(adminId == null) {
                    throw new Exception("Administrador no encontrado.");
                }

                Administrador admin = (Administrador)Sistema.Instancia.ObtenerUsuarioPorId(adminId ?? -1);
                if(admin == null) {
                    throw new Exception("Administrador no encontrado.");
                }
                subastaEncontrada.Finalizar(admin);

                TempData["MensajeExito"] = "Subasta cerrada exitosamente.";
                return RedirectToAction("Subastas");
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = ex.Message;
                return RedirectToAction("Subastas");
            }
        }
    }
}
