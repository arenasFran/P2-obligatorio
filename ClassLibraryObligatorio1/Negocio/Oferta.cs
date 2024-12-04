using BibliotecaClases.Personas;

namespace BibliotecaClases.Negocio
{
    public class Oferta
    {
        private static int _ultimoId = 1;
        private int _id;
        private double _cantidad;
        private Cliente _ofertadoPor;
        private DateTime _fecha;

        public Oferta(
            double cantidad,
            Cliente ofertadoPor,
            DateTime fecha
        ) {
            this.Id = ++_ultimoId;

            this.OfertadoPor = ofertadoPor;
            this.Cantidad = cantidad;
            this.Fecha = fecha;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public double Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public Cliente OfertadoPor
        {
            get { return _ofertadoPor; }
            set { _ofertadoPor = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

    }
}
