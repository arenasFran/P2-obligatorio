using BibliotecaClases.Negocio;
using BibliotecaClases;
using Microsoft.AspNetCore.Mvc;
using BibliotecaClases.Personas;
using WebAppMVC.Attributes;
namespace WebAppMVC.Controllers;

[Authenticate]
public class PublicacionesController : BaseController
{
    public IActionResult Publicaciones()
    {
        List<Publicacion> publicaciones = Sistema.Instancia.Publicaciones;

        ViewBag.Publicaciones = publicaciones;

        return View();
    }

    [HttpPost]

    public IActionResult Comprar(int publicacionId)
    {
        try
        {
            Publicacion? publicacionEncontrada = Sistema.Instancia.ObtenerPublicacionPorId(publicacionId);
            if (publicacionEncontrada == null)
            {
                throw new Exception("La publicación no existe.");
            }

            int? clienteId = HttpContext.Session.GetInt32("id");
            Cliente? cliente = Sistema.Instancia.ObtenerClientePorId(clienteId);
            if (cliente == null)
            {
                throw new Exception("Cliente no encontrado en el sistema.");
            }

            if (publicacionEncontrada is Venta venta)
            {
                venta.Finalizar(cliente);
                TempData["MensajeExito"] = "Compra realizada con éxito";
            }
        }
        catch (Exception ex)
        {
            TempData["MensajeError"] = ex.Message;
            return RedirectToAction("Publicaciones");
        }

        return RedirectToAction("Publicaciones");
    }



    [HttpPost]
    public IActionResult Subastar(int publicacionId, double cantidadOferta)
    {       
        try
        {
            Publicacion? publicacion = Sistema.Instancia.ObtenerPublicacionPorId(publicacionId);
            if (publicacion == null)
            {
                throw new Exception("La publicación no existe.");
            }

            int? clienteId = HttpContext.Session.GetInt32("id");
            Cliente cliente = Sistema.Instancia.ObtenerClientePorId(clienteId);

            if (cliente == null)
            {
               throw new Exception("Cliente no encontrado en el sistema.");     
            }

            if (publicacion is Subasta subasta)
            {
                subasta.AgregarOferta(new Oferta(cantidadOferta, cliente, DateTime.Now));
                TempData["MensajeExito"] = $"Oferta de {cantidadOferta:C} realizada con éxito.";
            }
            else
            {
               throw new Exception("La publicación no está disponible para subasta.");
            }
        }
        catch (Exception ex)
        {
            TempData["MensajeError"] = ex.Message;
            return RedirectToAction("Publicaciones");
        } 

        return RedirectToAction("Publicaciones");
    }
}