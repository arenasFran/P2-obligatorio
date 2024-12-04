using BibliotecaClases.Inventario;
using BibliotecaClases.Personas;

namespace BibliotecaClases.Negocio
{
    internal class GeneradorPublicacion
    {
        public static List<Venta> GenerarVentas(List<Articulo> articulos)
        {
            List<Venta> ventas = new List<Venta>
            {
                new Venta("Smartphone 5G", new DateTime(2024, 9, 15), true, new DateTime(2024, 9, 1), articulos.GetRange(0, 10)),
                new Venta("Auriculares Inalámbricos", new DateTime(2024, 9, 16), false, new DateTime(2024, 9, 3), articulos.GetRange(10, 3)),
                new Venta("Tablet de 10 Pulgadas", new DateTime(2024, 9, 18), true, new DateTime(2024, 9, 5), articulos.GetRange(3, 5)),
                new Venta("Cargador Rápido USB-C", new DateTime(2024, 9, 19), false, new DateTime(2024, 9, 6), articulos.GetRange(5, 3)),
                new Venta("Televisor 4K 55 Pulgadas", new DateTime(2024, 9, 20), true, new DateTime(2024, 9, 8), articulos.GetRange(8, 5)),
                new Venta("Reloj Inteligente", new DateTime(2024, 9, 21), false, new DateTime(2024, 9, 9), articulos.GetRange(1, 4)),
                new Venta("Teclado Mecánico", new DateTime(2024, 9, 22), true, new DateTime(2024, 9, 10), articulos.GetRange(4, 2)),
                new Venta("Cámara Web Full HD", new DateTime(2024, 9, 23), false, new DateTime(2024, 9, 12), articulos.GetRange(0, 3)),
                new Venta("Laptop Gaming", new DateTime(2024, 9, 24), true, new DateTime(2024, 9, 13), articulos.GetRange(6, 5)),
                new Venta("Funda para Smartphone", new DateTime(2024, 9, 25), false, new DateTime(2024, 6, 12), articulos.GetRange(2, 3)),
            };

            foreach (Venta venta in ventas)
            {
                if (venta.Precio <= 0)
                    throw new ArgumentException($"El precio de la venta {venta.Nombre} no es válido.");

                if (string.IsNullOrEmpty(venta.Nombre))
                    throw new ArgumentException($"El nombre no puede estar vacío");

                if (venta.Articulos.Count == 0)
                    throw new ArgumentException($"La venta {venta.Nombre} no tiene artículos");
            }
            return ventas;
        }

        public static List<Subasta> GenerarSubastas(List<Usuario> usuarios, List<Articulo> articulos)
        {
            List<Subasta> subastas = new List<Subasta>
            {
                new Subasta("Cámara de Fotos Vintage", new DateTime(2024, 9, 5), articulos.GetRange(0, 3)),
                new Subasta("Coche Clásico", new DateTime(2024, 9, 7), articulos.GetRange(3, 2)),
                new Subasta("Colección de Monedas", new DateTime(2024, 9, 9), articulos.GetRange(5, 3)),
                new Subasta("Reloj de Bolsillo", new DateTime(2024, 9, 11), articulos.GetRange(6, 1)),
                new Subasta("Jarrón de Porcelana", new DateTime(2024, 9, 13), articulos.GetRange(7, 1)),
                new Subasta("Mesa de Madera Antigua", new DateTime(2024, 9, 15), articulos.GetRange(8, 1)),
                new Subasta("Escultura en Bronce", new DateTime(2024, 9, 17), articulos.GetRange(9, 1)),
                new Subasta("Libro Antiguo", new DateTime(2024, 9, 19), articulos.GetRange(10, 2)),
                new Subasta("Smartphone Antiguo", new DateTime(2024, 9, 1), articulos.GetRange(11, 3)),
                new Subasta("Pintura de Artista Local", new DateTime(2024, 9, 3), articulos.GetRange(12, 2))
            };

            foreach (Subasta subasta in subastas)
            {
                if (string.IsNullOrEmpty(subasta.Nombre))
                    throw new ArgumentException("El nombre de la subasta no puede ser nulo o vacío.");

                if (subasta.Articulos.Count == 0)
                    throw new ArgumentException($"La subasta {subasta.Nombre} no tiene artículos asignados.");
            }

            List<Oferta> ofertas = new List<Oferta>
            {
                new Oferta(750.00, (Cliente)usuarios[4], DateTime.Now.AddHours(-5)),
                new Oferta(800.00, (Cliente)usuarios[5], DateTime.Now.AddDays(-3)),
                new Oferta(600.00, (Cliente)usuarios[6], DateTime.Now.AddDays(-6)),
                new Oferta(1200.00, (Cliente)usuarios[7], DateTime.Now.AddDays(-4)),
            };

            // Agregar ofertas a las subastas
            foreach (var oferta in ofertas.Take(2))
            {
                subastas[8].AgregarOferta(oferta); 
            }

            foreach (var oferta in ofertas.Skip(2))
            {
                subastas[9].AgregarOferta(oferta); 
            }

            return subastas;
        }
    }
}
