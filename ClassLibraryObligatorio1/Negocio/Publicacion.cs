using BibliotecaClases.Inventario;
using BibliotecaClases.Personas;

namespace BibliotecaClases.Negocio
{
    public abstract class Publicacion
    {
        private static int _ultimoId = 1;
        private int _id;
        private string _nombre;
        private EstadoPublicación _estado;
        private DateTime _fechaPublicacion;
        private List<Articulo> _articulos;
        private Cliente _compradoPor;
        private Usuario _finalizadoPor;
        private DateTime _finalizadoFecha;


        public Publicacion(string nombre, DateTime fechaPubli, List<Articulo> articulos)
        {
            Id = _ultimoId;
            ++_ultimoId;
            FechaPublicacion = fechaPubli;
            Nombre = nombre;
            Estado = EstadoPublicación.Abierta;
            _articulos = articulos;

        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public EstadoPublicación Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public List<Articulo> Articulos
        {
            get { return _articulos; }
            set { _articulos = value; }
        }

        public Cliente CompradoPor
        {
            get { return _compradoPor; }
            set { _compradoPor = value; }
        }

        public Usuario FinalizadoPor
        {
            get { return _finalizadoPor; }
            set { _finalizadoPor = value; }
        }

        public DateTime FechaPublicacion
        {
            get { return _fechaPublicacion; }
            set { _fechaPublicacion = value; }
        }

        public DateTime FinalizadoFecha
        {
            get { return _finalizadoFecha; }
            set { _finalizadoFecha = value; }
        }

        public virtual void Finalizar( Usuario finalizadoPor){
            FinalizadoFecha = DateTime.Now;
            FinalizadoPor = finalizadoPor;
        }

        public override string ToString()
        {
            return "Id: " + Id + ", Nombre: " + Nombre + ", Estado: " + Estado + ", Fecha de publicación: " + FechaPublicacion.ToShortDateString() +
                ", Cantidad de artículos: " + _articulos.Count;
        }
    }
}
