using BibliotecaClases.Inventario;
using BibliotecaClases.Personas;

namespace BibliotecaClases.Negocio
{
    public class Venta : Publicacion
    {
        private bool _ofertaRelampago;
        private DateTime _fechaVenta;
        private double _precio;
        

        public bool OfertaRelampago
        {
            get { return _ofertaRelampago; }
            set { _ofertaRelampago = value; }
        }

        public double Precio
        {
            get { return _precio; }
        }

        public DateTime FechaVenta
        {
            get
            {
                return _fechaVenta;
            }
            set { _fechaVenta = value; }
        }

        public Venta(string nombre,DateTime fechaVenta, bool ofertaRelampago,DateTime fechaPubli, List<Articulo> articulos): base(nombre,fechaPubli,articulos)
        {
            this._fechaVenta = fechaVenta ;
            this._ofertaRelampago=ofertaRelampago;
            foreach (Articulo articulo in articulos) {
                _precio += articulo.Precio;
            }
        }

        public override void Finalizar(Usuario finalizadoPor){
            if (Estado != EstadoPublicación.Abierta) {
                throw new Exception("Esta publicación no está abierta");
            }

            // Si es oferta relampago, se aplica un descuento del 20
            Cliente cliente = ((Cliente)finalizadoPor);
            cliente.RestarSaldo(this._precio * (OfertaRelampago ? 0.8 : 1));

            Estado = EstadoPublicación.Cerrada;

            base.Finalizar(finalizadoPor);
        }
    }
}
