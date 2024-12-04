namespace BibliotecaClases.Personas
{
    public abstract class Usuario
    {
        private static int _ultimoId = 1;
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _contraseña;
        private DateTime _fechaCreado;
        private string _rol;

        public Usuario(string nombre, string apellido, string email, string contraseña, string rol)
        {
            _id = _ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Contraseña = contraseña;
            Rol = rol;
            _fechaCreado = DateTime.Now;
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

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        public DateTime FechaCreado
        {
            get { return _fechaCreado; }
            set { _fechaCreado = value; }
        }

        public string Rol
        {
            get { return _rol; }
            private set { _rol = value; }
        }

        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                   string.IsNullOrEmpty(Apellido) ||
                   string.IsNullOrEmpty(Email) ||
                   string.IsNullOrEmpty(Contraseña))
            {
                throw new Exception("Todos los campos deben estar definidos: nombre, apellido, email, contraseña.");
            }
        }
    }
}
