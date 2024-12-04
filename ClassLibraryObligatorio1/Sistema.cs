using BibliotecaClases.Inventario;
using BibliotecaClases.Personas;
using BibliotecaClases.Negocio;

namespace BibliotecaClases
{
    public class Sistema
    {
        private static Sistema _instancia = new Sistema();
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Usuario> _usuarios = new List<Usuario>();

        public static Sistema Instancia
        {
            get { return _instancia; }
        }

       

        public void PrecargarDatos()
        {
            PrecargarUsuarios();
            PrecargarInventario();
            PrecargarNegocio();
        }

        private void PrecargarUsuarios()
        {
            _usuarios = GeneradorUsuario.GenerarUsuarios();
        }

        private void PrecargarInventario()
        {
            _articulos = GeneradorArticulo.GenerarArticulos();
        }

        private void PrecargarNegocio()
        {
            _publicaciones.AddRange(GeneradorPublicacion.GenerarVentas(_articulos));
            _publicaciones.AddRange(GeneradorPublicacion.GenerarSubastas(Usuarios, _articulos));
        }

        public List<Articulo> Articulos
        {
            get { return _articulos; }
        }

        public List<Publicacion> Publicaciones
        {
            get { return _publicaciones; }
        }

        public List<Usuario> Usuarios
        {
            get { return _usuarios; }
        }

        public static void ListarCategorias()
        {
            CategoriaArticulo[] categorias = (CategoriaArticulo[])Enum.GetValues(typeof(CategoriaArticulo));
            foreach (CategoriaArticulo categoria in categorias)
            {
                Console.WriteLine($"{(int)categoria}. {categoria}");
            }
        }

        public List<Subasta> FiltrarSubastas()
        {
            List<Subasta> subastas = new List<Subasta>();
            List<Publicacion> publis = Publicaciones;
            foreach (Publicacion p in publis)
            {

                if (p is Subasta s)
                {
                    subastas.Add(s);
                }
            }
            return subastas;
        }

        public void AgregarArticulo(Articulo articulo)
        {
            _articulos.Add(articulo);
        }

        public List<Publicacion> ListarPublicacionesPorFechas(DateTime fecha1, DateTime fecha2)
        {
            List<Publicacion> publicacionesFiltradas = new List<Publicacion>();
            foreach (Publicacion p in _publicaciones)
            {
                if (p.FechaPublicacion >= fecha1 && p.FechaPublicacion <= fecha2)
                {
                    publicacionesFiltradas.Add(p);
                }
            }
            return publicacionesFiltradas;
        }

        public Cliente? RegistrarCliente(string email, string password, string nombre, string apellido)
        {
            Cliente cliente = new Cliente(nombre, apellido, email, password, 0);
            cliente.Validar();

            Usuario? usuarioExistente = this.ObtenerUsuarioPorEmail(email);

            if(usuarioExistente != null) {
                throw new Exception("El email ya está en uso.");
            }

            Usuarios.Add(cliente);
            return cliente;
        }

        public Usuario Login(string email, string password)
        {
            Usuario? usuario = null;
            foreach(Usuario u in Usuarios)
            {
                if (u.Email == email && u.Contraseña == password)
                {
                    usuario = u;
                    break;
                }
            }
            
            if (usuario == null)
            {
                throw new Exception("Credenciales inválidas");
            }

            return usuario;
        }

        public Usuario? ObtenerUsuarioPorId(int id)
        {
            foreach (Usuario usuario in Usuarios)
            {
                if (usuario.Id == id) return usuario;
            }

            return null;
        }

        public Usuario? ObtenerUsuarioPorEmail(string email) {
            foreach (Usuario usuario in Usuarios) {
                if (usuario.Email == email) return usuario;
            }
            return null;
        }

        public Cliente? ObtenerClientePorId(int? id)
        {
            foreach (Usuario c in Usuarios)
            {
                if (c is Cliente cliente && cliente.Id == id) return cliente;
            }

            return null;
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            int index = -1;
            foreach (Usuario u in Usuarios)
            {
                if (u.Id == usuario.Id)
                {
                    index = Usuarios.IndexOf(u);
                    break;
                }
            }

            if (index != -1)
            {
                Usuarios[index] = usuario;
            }
        }


        public Subasta? ObtenerSubastaPorId(int publicacionId)
        {
            foreach (Subasta s in FiltrarSubastas())
            {
                if (s.Id == publicacionId)
                {
                    return s; 
                }
            }
            return null;
        }

        public Publicacion? ObtenerPublicacionPorId(int publicacionId)
        {
            foreach (Publicacion p in Publicaciones)
            { 
                if (p.Id == publicacionId)
                {
                     return p;
                }
               
               
            }
            return null;
        }
    }
}
